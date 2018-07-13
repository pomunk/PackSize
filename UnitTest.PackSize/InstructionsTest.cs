using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Moq;
using PackSize;

namespace UnitTest.PackSize
{
    [TestClass]
    public class InstructionsTest
    {
        private string _instructions;
        private PackSizeMachine _packSizeMachine;
        private Mock runInstructionsMock;
        private ITool _longCutTool;
        private ITool _crossCutTool;
        private ToolFactory _toolFactory;

        [TestInitialize]
        public void Setup()
        {
            _instructions = File.ReadAllText("Basic_Instructions.txt");
            _toolFactory = new ToolFactory();
            _packSizeMachine = new PackSizeMachine(_instructions, _toolFactory);
        }

        private void SetupCrossCutTool()
        {
            _crossCutTool = _toolFactory.CreateTool(ToolType.Cross_Cut, "0");
            _crossCutTool.Raise(HeadType.Crease);
            _crossCutTool.Raise(HeadType.Cut);
        }

        private void SetupLongCutTool()
        {
            _longCutTool = _toolFactory.CreateTool(ToolType.Long_Cut, "1");
            _longCutTool.Raise(HeadType.Crease);
            _longCutTool.Raise(HeadType.Cut);
        }

        [TestMethod]
        public void CrossHeadCreaseRaise()
        {
            SetupCrossCutTool();
            var expected = HeadStatus.Raised;
            _crossCutTool.Raise(HeadType.Crease);

            Assert.AreEqual(expected, _crossCutTool.GetCreaseHeadStatus());
        }

        [TestMethod]
        public void CrossHeadCreaseLower()
        {
            SetupCrossCutTool();
            var expected = HeadStatus.Lowered;
            _crossCutTool.Lower(HeadType.Crease);

            Assert.AreEqual(expected, _crossCutTool.GetCreaseHeadStatus());
        }

        [TestMethod]
        public void LongHeadCreaseRaise()
        {
            SetupLongCutTool();
            var expected = HeadStatus.Raised;
            _longCutTool.Raise(HeadType.Crease);

            Assert.AreEqual(expected, _longCutTool.GetCreaseHeadStatus());
        }

        [TestMethod]
        public void LongHeadCreaseLower()
        {
            SetupLongCutTool();
            var expected = HeadStatus.Lowered;
            _longCutTool.Lower(HeadType.Crease);

            Assert.AreEqual(expected, _longCutTool.GetCreaseHeadStatus());
        }

        [TestMethod]
        public void CrossHeadCutRaise()
        {
            SetupCrossCutTool();
            var expected = HeadStatus.Raised;
            _crossCutTool.Raise(HeadType.Cut);

            Assert.AreEqual(expected, _crossCutTool.GetCutHeadStatus());
        }

        [TestMethod]
        public void CrossHeadCutLower()
        {
            SetupCrossCutTool();
            var expected = HeadStatus.Lowered;
            _crossCutTool.Lower(HeadType.Cut);

            Assert.AreEqual(expected, _crossCutTool.GetCutHeadStatus());
        }

        [TestMethod]
        public void LongHeadCutRaise()
        {
            SetupLongCutTool();
            var expected = HeadStatus.Raised;
            _longCutTool.Raise(HeadType.Cut);

            Assert.AreEqual(expected, _longCutTool.GetCutHeadStatus());
        }

        [TestMethod]
        public void LongHeadCutLower()
        {
            SetupLongCutTool();
            var expected = HeadStatus.Lowered;
            _longCutTool.Lower(HeadType.Cut);

            Assert.AreEqual(expected, _longCutTool.GetCutHeadStatus());
        }

        [TestMethod]
        public void CutCrossHeadRight()
        {
            SetupCrossCutTool();
            _crossCutTool.Move(0);
            _packSizeMachine.MoveCross(new Coordinate() { X = 0, Y = 0 }, _crossCutTool , HeadType.Cut, TravelDirection.Right, 5);
            
            var expected = 5;
            var actual = _crossCutTool.CurrentXCoordinate;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CutCrossHeadLeft()
        {
            SetupCrossCutTool();
            _packSizeMachine.MoveCross(new Coordinate() { X = 15, Y = 0 }, _crossCutTool, HeadType.Cut, TravelDirection.Left, 5);

            var expected = 10;
            var actual = _crossCutTool.CurrentXCoordinate;

            Assert.AreEqual(expected, actual);
        }

  
        [TestMethod]
        public void CutLongHead()
        {
            SetupLongCutTool();
            _packSizeMachine.Feed(10);
            var expected = 10;
            var actual = _packSizeMachine.CurrentYCoordinates;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RunTheGambit()
        {
            _packSizeMachine.ProcessInstructions();
        }



    }
}
