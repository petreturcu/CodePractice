namespace StaticManualDI
{
    using Interfaces;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Providers.GetProvider<IDataProvider>().Description());
            Console.WriteLine(Providers.GetProvider<IEmailProvider>().Description());
            Console.WriteLine(Providers.GetProvider<IUserProvider>().Description());

            Providers.RegisterProvider<IEmailProvider>(new ImapEmailProvider());
            Console.WriteLine(Providers.GetProvider<IEmailProvider>().Description());
        }
    }
}
