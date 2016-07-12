namespace StaticManualDI
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public static class Providers
    {
        private static readonly Dictionary<Type, Type> providersDictionary = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, object> singletonDictionary = new Dictionary<Type, object>();

        public static T GetTransient<T>() where T : class
        {
            Type concreteType;
            if (providersDictionary.TryGetValue(typeof(T), out concreteType)) return (T)Activator.CreateInstance(concreteType);

            throw new Exception($"No provider of type {typeof(T)} found.");
        }

        public static T GetSingleton<T>() where T : class
        {
            object concrete;
            if (singletonDictionary.TryGetValue(typeof(T), out concrete))
                return (T)concrete;

            Type concreteType;
            if (providersDictionary.TryGetValue(typeof(T), out concreteType))
            {
                singletonDictionary.Add(typeof(T), Activator.CreateInstance(concreteType));
                return GetSingleton<T>();
            }

            throw new Exception($"No provider of type {typeof(T)} found.");
        }

        public static void RegisterProvider<TInterface, TConcrete>()
            where TInterface : class
            where TConcrete : TInterface
        {
            if (providersDictionary.ContainsKey(typeof(TInterface)))
                providersDictionary[typeof(TInterface)] = typeof(TConcrete);
            else
                providersDictionary.Add(typeof(TInterface), typeof(TConcrete));
        }
    }
}