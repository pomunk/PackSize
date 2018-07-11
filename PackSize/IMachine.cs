using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public interface IMachine
    {
        void ProcessInstructions();
        void MoveLong(Coordinate startingCoordinate, ITool tool, HeadType type, TravelDirection direction, int length);
        void MoveCross(Coordinate startingCoordinate, ITool tool, HeadType type, TravelDirection direction, int length, bool IsLastInstruction);
    }
}
