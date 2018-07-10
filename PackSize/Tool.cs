using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    public abstract class Tool : ITool
    {
        private ToolHead _cutHead;
        private ToolHead _creaseHead;
        private Logger _logger;

        public Tool()
        {
            _cutHead = new ToolHead(HeadType.Cut);
            _creaseHead = new ToolHead(HeadType.Crease);
        }

        public Logger Logger { get => _logger; set => _logger = value; }

        public HeadStatus GetCreaseHeadStatus()
        {
            return _creaseHead.Status;
        }

        public HeadStatus GetCutHeadStatus()
        {
            return _cutHead.Status;
        }

        public void Lower(HeadType toolType)
        {
            if (toolType == HeadType.Crease)
            {
                _cutHead.Raise();
                _creaseHead.Lower();
            }
            else
            {
                _creaseHead.Raise();
                _cutHead.Lower();
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Raise(HeadType toolType)
        {
            if (toolType == HeadType.Cut)
            {
                _cutHead.Raise();
            }
            else
            {
                _creaseHead.Raise();
            }
        }
    }
}
