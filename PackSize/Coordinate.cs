using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class Coordinate
    {
        private int _xCoordinate;
        private int _yCoordinate;

        public int X { get => _xCoordinate; set => _xCoordinate = value; }
        public int Y { get => _yCoordinate; set => _yCoordinate = value; }
    }
}
