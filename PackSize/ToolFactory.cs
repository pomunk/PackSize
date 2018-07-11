using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class ToolFactory
    {
        public virtual Tool CreateTool(ToolType toolType, string id)
        {
           Tool tool = null;

            switch (toolType)
            {
                case ToolType.Cross_Cut:
                    tool = new CrosscutTool(id);
                    break;
                case ToolType.Long_Cut:
                    tool = new LongcutTool(id);
                    break;
                default:
                    break;
            }
            
            return tool;
        }
    }
}
