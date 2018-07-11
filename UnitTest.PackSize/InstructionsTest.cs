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
            var expected = true;
            var actual = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CutCrossHeadLeft()
        {
            var expected = true;
            var actual = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreaseCrossHeadRight()
        {
            var expected = true;
            var actual = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreaseCrossHeadLeft()
        {
            var expected = true;
            var actual = false;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CutLongHead()
        {
            var expected = true;
            var actual = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreaseLongHead()
        {
            var expected = true;
            var actual = false;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Feed()
        {
            var expected = true;
            var actual = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RaiseLongHeadCut() { }

        [TestMethod]
        public void LowerLongHeadCut() { }

        [TestMethod]
        public void RaiseCrossHeadCut() { }

        [TestMethod]
        public void LowerCrossHeadCut() { }

        [TestMethod]
        public void RaiseLongHeadCrease() { }

        [TestMethod]
        public void LowerLongHeadCrease() { }

        [TestMethod]
        public void RaiseCrossHeadCrease() { }

        [TestMethod]
        public void LowerCrossHeadCrease() { }

        [TestMethod]
        public void FeedFanFold() { }

        [TestMethod]
        public void RunTheGambit()
        {
            _packSizeMachine.ProcessInstructions();
        }



    }
}
