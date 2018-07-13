using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class CrosscutTool : Tool, ITool
    {
        public CrosscutTool(string id)
        {
            base.Id = id;
        }

        public void Raise(HeadType toolType)
        {
            base.Raise(toolType);
            Logger.Log(string.Format("Raise cross-head {0},", toolType == HeadType.Crease ? "crease" : "knife"));
        }

        public override void Raise()
        {
            if (base.GetCreaseHeadStatus() == HeadStatus.Lowered)
                this.Raise(HeadType.Crease);
            if (base.GetCutHeadStatus() == HeadStatus.Lowered)
                this.Raise(HeadType.Cut);
        }

        public void Lower(HeadType toolType)
        {
            base.Lower(toolType);
            Logger.Log(string.Format("Lower cross-head {0},", toolType == HeadType.Crease ? "crease" : "knife"));
        }

        public override void Move(int xCoordinate)
        {
            CurrentXCoordinate = xCoordinate;
            Logger.Log(string.Format("Move cross-head to {0},", xCoordinate));
        }
    }
}
