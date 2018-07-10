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
            
            container.Register(Component.For<IRunInstructions>().ImplementedBy<RunInstructions>());
            //var root = container.Resolve<IRunInstructions>(args[0], logger );
            string text = File.ReadAllText("Basic_Instructions.txt");
            var root = container.Resolve<IRunInstructions>(new { instructionSet = text });
            root.ProcessInstructions();

        }
    }
}
