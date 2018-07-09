using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class Instruction
    {
        private int _number;
        private InstructionType instructionType;
        private TravelDirection travelDirection;
        private Coordinate _startingCoordinate;
        private int _length;

        public int Number { get => _number; set => _number = value; }
        public InstructionType InstructionType { get => instructionType; set => instructionType = value; }
        public TravelDirection TravelDirection { get => travelDirection; set => travelDirection = value; }
        public Coordinate StartingCoordinate { get => _startingCoordinate; set => _startingCoordinate = value; }
        public int Length { get => _length; set => _length = value; }
    }
}
