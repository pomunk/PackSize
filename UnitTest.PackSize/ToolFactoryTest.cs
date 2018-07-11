using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackSize;


namespace UnitTest.PackSize
{
    [TestClass]
    public class ToolFactoryTest
    {
        private ToolFactory factory;

        [TestInitialize]
        public void Setup() {
            factory = new ToolFactory();

        }

        [TestMethod]
        public void CreateCrossCutTool() {
            ITool tool = factory.CreateTool(ToolType.Cross_Cut, "0");

            Assert.IsTrue(tool.GetType() == typeof(CrosscutTool));
        }

        [TestMethod]
        public void CreateLongCutTool() {
            ITool tool = (LongcutTool)factory.CreateTool(ToolType.Long_Cut, "0");

            Assert.IsTrue(tool.GetType() == typeof(LongcutTool));
        }

    }
}
