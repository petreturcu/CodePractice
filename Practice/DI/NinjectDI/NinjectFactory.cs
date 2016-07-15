namespace NinjectDI
{
    using Ninject;
    using Ninject.Modules;

    public class NinjectFactory
    {
        public static IKernel kernel = null;

        public static IKernel GetNinjectKernel()
        {
            if (kernel != null) return kernel;

            INinjectModule module = new Program.CustomModule();
            kernel = new StandardKernel(module);

            return kernel;
        }
    }
}