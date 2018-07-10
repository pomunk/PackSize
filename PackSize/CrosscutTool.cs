using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class CrosscutTool : Tool
    {
        public CrosscutTool(Logger logger)
        {
            Logger = logger;
        }

        public void Raise(HeadType toolType)
        {
            base.Raise(toolType);
            Logger.Log(string.Format("Raise cross-head {0}", toolType.ToString()));
        }

        public void Lower(HeadType toolType)
        {
            base.Raise(toolType);
            Logger.Log(string.Format("Lower cross-head {0}", toolType.ToString()));
        }

    }
}
