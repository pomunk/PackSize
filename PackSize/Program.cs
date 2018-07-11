using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.IO;

namespace PackSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            
            container.Register(Component.For<IMachine>().ImplementedBy<PackSizeMachine>());
            ToolFactory factory = new ToolFactory();
            var root = container.Resolve<IMachine>(new { instructionSet = args[0], factory = factory });
            root.ProcessInstructions();
        }
    }
}
