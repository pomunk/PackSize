using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PackSize
{
    public class PackSizeMachine : IMachine
    {
        private Coordinate _currentCoordinates;
        private List<Instruction> _instructionSet;

        public PackSizeMachine(string instructionSet)
        {
            _instructionSet = JsonConvert.DeserializeObject<List<Instruction>>(instructionSet);
        }

        public Coordinate CurrentCoordinates { get => _currentCoordinates; set => _currentCoordinates = value; }
        public List<Instruction> InstructionSet { get => _instructionSet; set => _instructionSet = value; }

        public void ProcessInstructions()
        {
            foreach(var instruction in InstructionSet)
            {
                
            }
        }

        public void Move(Coordinate startingCoordinate, HeadType type, TravelDirection direction, int length)
        {

        }
    }
}
