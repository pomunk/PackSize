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
        private string _id;
        private int currentXCoordinate;
        private int currentYCoordinate;

        public Tool()
        {
            _cutHead = new ToolHead(HeadType.Cut);
            _creaseHead = new ToolHead(HeadType.Crease);
            Logger = Logger.Instance;
        }

        public Logger Logger { get => _logger; set => _logger = value; }
        public string Id { get => _id; set => _id = value; }
        public int CurrentXCoordinate { get => currentXCoordinate; set => currentXCoordinate = value; }
        public int CurrentYCoordinate { get => currentYCoordinate; set => currentYCoordinate = value; }

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
                _creaseHead.Lower();
            }
            else
            {
                _cutHead.Lower();
            }
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

        public abstract void Raise();
        public abstract void Move(int coordinate);
    }
}
