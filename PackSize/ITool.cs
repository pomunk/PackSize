using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public interface ITool
    {
        void Raise(HeadType toolType);
        void Lower(HeadType toolType);
        void Move();
        HeadStatus GetCreaseHeadStatus();
        HeadStatus GetCutHeadStatus();
    }
}
