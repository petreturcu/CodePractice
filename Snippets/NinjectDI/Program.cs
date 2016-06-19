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

            var programmer = kernel.Get<MicrosoftProgrammer>();
            Console.WriteLine(programmer.GetType().Name);
            programmer.WriteCode();

            var programmer2 = kernel.Get<JavaProgrammer>();
            Console.WriteLine("\n" + programmer2.GetType().Name);
            programmer2.WriteCode();
        }
    }

    public class CustomModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<Programmer>().ToSelf();
            this.Bind<ICaffeinated>().To<DietCoke>().WhenInjectedInto<MicrosoftProgrammer>();
            this.Bind<ICaffeinated>().To<PepsiMax>().WhenInjectedInto<JavaProgrammer>();

            this.Bind<IEditor>().To<VisualStudio>().When(request => request.Target.Member.DeclaringType == typeof(MicrosoftProgrammer));
            this.Bind<IEditor>().To<Eclipse>().WhenInjectedInto<JavaProgrammer>();
        }
    }
}
