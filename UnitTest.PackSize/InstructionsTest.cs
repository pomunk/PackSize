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
        private RunInstructions runInstructions;
        private Mock runInstructionsMock;
        private Mock longCutToolMock;
        private Mock crossCutToolMock;
        private Mock loggerMock;

        [TestInitialize]
        public void Setup()
        {
            //var container = new WindsorContainer();

            //container.Register(Component.For<IRunInstructions>().ImplementedBy<RunInstructions>());

            //runInstructions = (RunInstructions)container.Resolve<IRunInstructions>(File.ReadAllText("Basic_Instructions.txt"));
            loggerMock = new Mock<ILogger>();
            //runInstructionsMock = new Mock<IRunInstructions>(File.ReadAllText("Basic_Instructions.txt"));

            //longCutToolMock = new Mock<LongcutTool>(loggerMock);
            //crossCutToolMock = new Mock<CrosscutTool>();

        }


        [TestMethod]
        public void CrossHeadCreaseRaise()
        {
            CrosscutTool tool = new CrosscutTool((Logger)loggerMock.Object);
            var expected = true;
            var actual = tool.Raise(HeadType.Crease);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CrossHeadCreaseLower()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongHeadCreaseRaise()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongHeadCreaseLower()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CrossHeadCutRaise()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CrossHeadCutLower()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongHeadCutRaise()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LongHeadCutLower()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CutCrossHeadRight()
        {
            var expected = true;
            var actual = runInstructionsMock.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CutCrossHeadLeft()
        {
            var expected = true;
            var actual = _instructions.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreaseCrossHeadRight()
        {
            var expected = true;
            var actual = _instructions.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreaseCrossHeadLeft()
        {
            var expected = true;
            var actual = _instructions.Move();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CutLongHead()
        {
            var expected = true;
            var actual = _instructions.Move();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreaseLongHead()
        {
            var expected = true;
            var actual = _instructions.Move();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FeedLongHead()
        {
            var expected = true;
            var actual = _instructions.Move();

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



    }
}
