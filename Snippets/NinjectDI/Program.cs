using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDI
{
    using Ninject;
    using Ninject.Modules;

    class Program
    {
        static void Main(string[] args)
        {
            CustomModule module = new CustomModule();
            IKernel kernel = new StandardKernel(module);

            var programmer = kernel.Get<Programmer>();

            Console.WriteLine(programmer.WriteCode());
        }
    }

    public class CustomModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<Programmer>().ToSelf();
            this.Bind<ICaffeinated>().To<DietCoke>();

        }
    }
}
