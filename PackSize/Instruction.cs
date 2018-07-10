using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class Instruction
    {
        private int _number;
        private HeadType instructionType;
        private TravelDirection travelDirection;
        private Coordinate _startingCoordinate;
        private int _length;

        public int InstructionNumber { get => _number; set => _number = value; }
        public HeadType Type { get => instructionType; set => instructionType = value; }
        public TravelDirection TravelDirection { get => travelDirection; set => travelDirection = value; }
        public Coordinate StartingCoordinate { get => _startingCoordinate; set => _startingCoordinate = value; }
        public int Length { get => _length; set => _length = value; }
    }
}
