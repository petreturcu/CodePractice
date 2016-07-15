namespace StaticManualDI
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    public static class Providers
    {
        private static readonly Dictionary<Type, object> providersDictionary = new Dictionary<Type, object>();

        public static T GetProvider<T>() where T : class
        {
            object provider;
            if (providersDictionary.TryGetValue(typeof(T), out provider)) return (T)provider;

            if (typeof(T) == typeof(IDataProvider))
            {
                RegisterProvider<IDataProvider>(new SqlServerDataProvider());
                return GetProvider<T>();
            }

            if (typeof(T) == typeof(IEmailProvider))
            {
                RegisterProvider<IEmailProvider>(new SmptEmailProvider());
                return GetProvider<T>();
            }

            if (typeof(T) == typeof(IUserProvider))
            {
                RegisterProvider<IUserProvider>(new SqlServerUserProvider());
                return GetProvider<T>();
            }

            // add others here

            return null;
        }

        public static void RegisterProvider<T>(T provider)
        {
            if (providersDictionary.ContainsKey(typeof(T)))
                providersDictionary[typeof(T)] = provider;
            else
                providersDictionary.Add(typeof(T), provider);
        }
    }
}