// -----------------------------------------------------------------------
// <copyright file = "MyConfig.cs" author = "Petre Turcu" company = "LadApps">
//      Copyright (c) 10/04/2016
// </copyright>
// -----------------------------------------------------------------------
namespace MyConfiguration.Config
{
    using System.Configuration;
    public class MyConfig : ConfigurationSection
    {
        public static MyConfig Settings { get; } = (MyConfig)ConfigurationManager.GetSection("settings");

        [ConfigurationProperty("account")]
        public AccountElement Account => (AccountElement)base["account"];
    }

    public class AccountElement : ConfigurationElement
    {
        [ConfigurationProperty("accountId")]
        public string AccountId => (string)base["accountId"];

        [ConfigurationProperty("authToken")]
        public string AuthToken => (string)base["authToken"];

        [ConfigurationProperty("password")]
        public string Password => (string)base["password"];
    }
}