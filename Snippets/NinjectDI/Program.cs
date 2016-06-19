﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectDI
{
    using System.Threading;

    using Ninject;
    using Ninject.Modules;

    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = NinjectFactory.GetNinjectKernel();

            var drink = kernel.Get<ICaffeinated>();
            drink.Drink();

            var mre = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(DrinkCaffeine, mre);
            mre.WaitOne();

            drink = kernel.Get<ICaffeinated>();
            drink.Drink();

            Console.WriteLine(drink.DrinkCount);

            /*            var programmer = kernel.Get<MicrosoftProgrammer>();
                        Console.WriteLine(programmer.GetType().Name);
                        programmer.WriteCode();

                        programmer = kernel.Get<MicrosoftProgrammer>();
                        Console.WriteLine("/n" + programmer.GetType().Name);
                        programmer.WriteCode();

                        Console.WriteLine();*/

            /*            var programmer2 = kernel.Get<JavaProgrammer>();
                        Console.WriteLine("\n" + programmer2.GetType().Name);
                        programmer2.WriteCode();*/
        }

        public static void DrinkCaffeine(object state)
        {
            IKernel kernel = NinjectFactory.GetNinjectKernel();

            var drink = kernel.Get<ICaffeinated>();
            drink.Drink();

            Console.WriteLine(drink.DrinkCount);
            ((ManualResetEvent)state).Set();
        }
        public class CustomModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<Programmer>().ToSelf();
                //this.Bind<ICaffeinated>().To<DietCoke>().InSingletonScope();
                this.Bind<ICaffeinated>().To<DietCoke>().InThreadScope();

                this.Bind<ICaffeinated>().To<DietCoke>().WhenInjectedInto<MicrosoftProgrammer>().InSingletonScope();
                this.Bind<ICaffeinated>().To<PepsiMax>().WhenInjectedInto<JavaProgrammer>();

                this.Bind<IEditor>().To<VisualStudio>().When(request => request.Target.Member.DeclaringType == typeof(MicrosoftProgrammer));
                this.Bind<IEditor>().To<Eclipse>().WhenInjectedInto<JavaProgrammer>();
            }
        }
    }
}
