using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class LongcutTool : Tool, ITool
    {
        
        public LongcutTool(string id)
        {
            base.Id = id;
        }

        public void Raise(HeadType toolType)
        {
            base.Raise(toolType);
            Logger.Log(string.Format("Raise long-head {0} {1},", Id, toolType == HeadType.Crease ? "crease" : "knife"));
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
            if(toolType == HeadType.Crease)
            {
                if (base.GetCutHeadStatus() == HeadStatus.Lowered)
                   this. Raise(HeadType.Cut);
                if (base.GetCreaseHeadStatus() == HeadStatus.Lowered)
                    return;
            }
            else
            {
                if (base.GetCreaseHeadStatus() == HeadStatus.Lowered)
                    this.Raise(HeadType.Crease);
                if (base.GetCutHeadStatus() == HeadStatus.Lowered)
                    return;
            }
            
            base.Lower(toolType);
            Logger.Log(string.Format("Lower long-head {0} {1},", Id, toolType == HeadType.Crease ? "crease" : "knife"));
        }

        public override void Move(int coordinate)
        {
            CurrentXCoordinate = coordinate;
            Logger.Log(string.Format("Move long-head {0} to {1},", Id, coordinate));
        }
    }
}
