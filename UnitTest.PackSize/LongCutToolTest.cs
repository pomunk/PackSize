using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PackSize;

namespace UnitTest.PackSize
{
    [TestClass]
    public class LongCutToolTest
    {
        private ToolFactory factory;
        private ITool longcutTool;

        [TestInitialize]
        public void Setup()
        {
            factory = new ToolFactory();
            longcutTool = factory.CreateTool(ToolType.Long_Cut, "1");
        }

        [TestMethod]
        public void RaiseTest()
        {
            longcutTool.Raise(HeadType.Crease);

            Assert.IsTrue(longcutTool.GetCreaseHeadStatus() == HeadStatus.Raised);
        }

        [TestMethod]
        public void LowerTest()
        {
            longcutTool.Lower(HeadType.Crease);

            Assert.IsTrue(longcutTool.GetCreaseHeadStatus() == HeadStatus.Lowered);
        }
    }
}
