using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace PackSize
{
    public class PackSizeMachine : IMachine
    {
        private int _currentCoordinates;
        private List<Instruction> _instructionSet;
        private List<List<Instruction>> _groupedInstructionSet;
        private List<Instruction> _longCutInstructionSet;
        private List<int> _longCutYCoordinates;
        private int _longCutHeadIndex;
        private int _nextLongCut;
        private ITool _crossCutTool;
        private ITool _longcutToolLeft;
        private ITool _longcutToolCenterLeft;
        private ITool _longcutToolCenterRight;
        private ITool _longcutToolRight;

        private const int MAXINCHES = 30;
        private const int NUMLONGCUTHEADS = 4;

        public PackSizeMachine(string instructionSet, ToolFactory factory)
        {
            _nextLongCut = 0;
            _longCutHeadIndex = 0;
            _crossCutTool = factory.CreateTool(ToolType.Cross_Cut, "0");
            _longcutToolLeft = factory.CreateTool(ToolType.Long_Cut, "0");
            _longcutToolCenterLeft = factory.CreateTool(ToolType.Long_Cut, "1");
            _longcutToolCenterRight = factory.CreateTool(ToolType.Long_Cut, "2");
            _longcutToolRight = factory.CreateTool(ToolType.Long_Cut, "3");
            CurrentYCoordinates = 0;
            InstructionSet = new List<List<Instruction>>();
            _instructionSet = JsonConvert.DeserializeObject<List<Instruction>>(instructionSet).OrderBy(x => x.InstructionNumber).ToList();
        }

        public int CurrentYCoordinates { get => _currentCoordinates; set => _currentCoordinates = value; }
        public List<List<Instruction>> InstructionSet { get => _groupedInstructionSet; set => _groupedInstructionSet = value; }

        private void PreProcessInstructions()
        {
            _longCutInstructionSet = _instructionSet.Select(x => x).Where(x => x.TravelDirection == TravelDirection.Feed).OrderBy(x => x.InstructionNumber).ToList();
            _instructionSet = _instructionSet.Where( x => !_longCutInstructionSet.Select(y => y.InstructionNumber).Contains(x.InstructionNumber)).ToList();
            var yCoordinateSet = _instructionSet.Select(x => x.StartingCoordinate.Y).Distinct().OrderBy(y => y).ToList();
            foreach (var yCoordinate in yCoordinateSet)
            {
                InstructionSet.Add( _instructionSet.Select(x => x).Where(x => x.StartingCoordinate.Y == yCoordinate).OrderBy(x => x.InstructionNumber).ToList());
            }
            _longCutYCoordinates = _longCutInstructionSet.Select(x => x.StartingCoordinate.Y).Distinct().OrderBy(y => y).ToList();
            _nextLongCut = _longCutYCoordinates.First();            
            _crossCutTool.Move(0);
        }

        public void SetLongCutXCoordinates(List<Instruction> longCuts)
        {
            if(_longcutToolCenterLeft.CurrentXCoordinate != longCuts[1].StartingCoordinate.X)
                _longcutToolCenterLeft.Move(longCuts[1].StartingCoordinate.X);
            _longcutToolCenterLeft.Lower(longCuts[1].Type);
            if (_longcutToolCenterRight.CurrentXCoordinate != longCuts[2].StartingCoordinate.X)
                _longcutToolCenterRight.Move(longCuts[2].StartingCoordinate.X);
            _longcutToolCenterRight.Lower(longCuts[2].Type);
            if (_longcutToolRight.CurrentXCoordinate != longCuts[3].StartingCoordinate.X)
                _longcutToolRight.Move(longCuts[3].StartingCoordinate.X);
            _longcutToolRight.Lower(longCuts[3].Type);
        }

        private void GetNextLongCutSet()
        {
            SetLongCutXCoordinates(_longCutInstructionSet.Skip(_longCutHeadIndex).Take(NUMLONGCUTHEADS).ToList());
            _longCutHeadIndex += NUMLONGCUTHEADS;
        }

        public void ProcessInstructions()
        {
            PreProcessInstructions();

            for(int subSetIndex = 0; subSetIndex < InstructionSet.Count; subSetIndex++)
            {
                var subSet = InstructionSet[subSetIndex];
                int currenty = subSet[0].StartingCoordinate.Y;
                foreach (var instruction in subSet)
                {
                    switch (instruction.TravelDirection)
                    {
                        case TravelDirection.Feed:
                            break;
                        case TravelDirection.Left:
                        case TravelDirection.Right:                        
                            MoveCross(instruction.StartingCoordinate, _crossCutTool, instruction.Type, instruction.TravelDirection, instruction.Length, (subSetIndex == InstructionSet.Count - 1));
                            break;
                        default:
                            break;
                    }
                }

                if (currenty == _nextLongCut)
                {
                    GetNextLongCutSet();
                    if (_longCutYCoordinates.Count > 1)
                    {
                        _longCutYCoordinates.RemoveAt(0);
                        _nextLongCut = _longCutYCoordinates.First();
                    }
                    else
                        _nextLongCut = -1;
                }
            }
        }

        private void RaiseAllLongCutHeads()
        {
            _longcutToolCenterLeft.Raise();
            _longcutToolCenterRight.Raise();
            _longcutToolRight.Raise();
        }

        public void Feed(int length)
        {
            CurrentYCoordinates += length;
            Logger.Instance.Log("");
            Logger.Instance.Log(string.Format("Feed fanfold {0},", length));
        }

        public void MoveCross(Coordinate startingCoordinate, ITool tool, HeadType type, TravelDirection direction, int length, bool IsLastInstruction = false)
        {
            int coordinate = startingCoordinate.X;
            if(startingCoordinate.Y > CurrentYCoordinates)
            {
                Feed(startingCoordinate.Y - CurrentYCoordinates);
                CurrentYCoordinates = startingCoordinate.Y;
            }
            if (IsLastInstruction)
                {
                    RaiseAllLongCutHeads();
                }
            if (direction == TravelDirection.Right)
                coordinate += length;
            else
                coordinate -= length;
            tool.Lower(type);
            tool.Move(coordinate);
            tool.Raise(type);
        }

        public void MoveLong(Coordinate startingCoordinate, ITool tool, HeadType type, TravelDirection direction, int length)
        {
            int coordinate = startingCoordinate.Y;
            tool.Move(coordinate);
                coordinate += length;
            tool.Lower(type);
            tool.Move(coordinate);
            tool.Raise(type);
        }
    }
}
