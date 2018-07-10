using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public class ToolHead
    {
        private HeadStatus _status;
        private HeadType _headType;

        public ToolHead( HeadType headType)
        {
            HeadType = headType;
        }

        public HeadStatus Status { get => _status; set => _status = value; }
        public HeadType HeadType { get => _headType; set => _headType = value; }

        public void Raise()
        {
            Status = HeadStatus.Raised;
        }

        public void Lower()
        {
            Status = HeadStatus.Lowered;
        }
    }
}
