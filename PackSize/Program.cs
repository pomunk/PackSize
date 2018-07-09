using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;

namespace PackSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            
            container.Register(Component.For<IRunInstructions>().ImplementedBy<RunInstructions>());
            
            var root = container.Resolve<IRunInstructions>(args[0]);
            
        }
    }
}
