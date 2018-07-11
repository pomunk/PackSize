using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public interface ITool
    {
        int CurrentXCoordinate { get; }

        void Raise(HeadType toolType);
        void Raise();
        void Lower(HeadType toolType);
        void Move(int coordinate);
        HeadStatus GetCreaseHeadStatus();
        HeadStatus GetCutHeadStatus();
    }
}
