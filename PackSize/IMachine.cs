using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public interface IMachine
    {
        void ProcessInstructions();
        Coordinate Move(Coordinate startingCoordinate, ITool tool, HeadType type, TravelDirection direction, int length);
    }
}
