using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackSize;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.PackSize
{
    [TestClass]
    public class ToolHeadTest
    {
        private ToolHead toolHead;

        [TestInitialize]
        public void SetUp()
        {
            toolHead = new ToolHead(HeadType.Crease);
        }

        [TestMethod]
        public void RaiseHeadTest()
        {
            toolHead.Raise();
            Assert.IsTrue(toolHead.Status == HeadStatus.Raised);
        }

        [TestMethod]
        public void LowerHeadTest()
        {
            toolHead.Lower();
            Assert.IsTrue(toolHead.Status == HeadStatus.Lowered);
        }
    }
}
