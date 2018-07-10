using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class LongcutTool : Tool
    {
        private string _id;
        public string Id { get => _id; set => _id = value; }

        public LongcutTool()
        {
        }

        public void Raise(HeadType toolType)
        {
            base.Raise(toolType);
            Logger.Log(string.Format("Raise long-head {0} {1}", Id, toolType.ToString()));
        }

        public void Lower(HeadType toolType)
        {
            base.Raise(toolType);
            Logger.Log(string.Format("Lower long-head {0} {1}", Id, toolType.ToString()));
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
