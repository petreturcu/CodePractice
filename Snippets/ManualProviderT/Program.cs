namespace StaticManualDI
{
    using System;
    using Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            //register concretes to interfaces
            Providers.RegisterProvider<IEmailProvider, SmptEmailProvider>();
            Providers.RegisterProvider<IDataProvider, SqlServerDataProvider>();
            Providers.RegisterProvider<IUserProvider, SqlServerUserProvider>();

            // test
            Console.WriteLine(Providers.GetTransient<IDataProvider>().Description());
            Console.WriteLine(Providers.GetTransient<IEmailProvider>().Description());
            Console.WriteLine(Providers.GetTransient<IUserProvider>().Description());

            Providers.RegisterProvider<IEmailProvider, ImapEmailProvider>();
            Console.WriteLine(Providers.GetTransient<IEmailProvider>().Description());

            // check singletons and transients are different
            Console.WriteLine(Providers.GetTransient<IEmailProvider>().Equals(Providers.GetTransient<IEmailProvider>()));
            Console.WriteLine(Providers.GetSingleton<IEmailProvider>().Equals(Providers.GetTransient<IEmailProvider>()));
            Console.WriteLine(Providers.GetSingleton<IEmailProvider>().Equals(Providers.GetSingleton<IEmailProvider>()));
        }
    }
}
