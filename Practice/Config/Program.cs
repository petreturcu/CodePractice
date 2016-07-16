// -----------------------------------------------------------------------
// <copyright file = "Program.cs" author = "Petre Turcu" company = "LadApps">
//      Copyright (c) 10/04/2016
// </copyright>
// -----------------------------------------------------------------------
namespace MyConfiguration
{
    using System;

    using MyConfiguration.Config;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Configs: \n");
            Console.WriteLine(MyConfig.Settings.Account.AccountId);
            Console.WriteLine(MyConfig.Settings.Account.AuthToken);
            Console.WriteLine(MyConfig.Settings.Account.ToString());
        }
    }
}