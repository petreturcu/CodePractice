namespace ExtendingWebApi.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ObjectExtensions
    {
        public static object GetPropValue(this object src, PropertyInfo prop)
        {
            return prop.GetValue(src, null);
        }

        public static IEnumerable<PropertyInfo> GetPropsOfType<T>(this object src)
        {
            return src.GetType().GetProperties().Where(p => p.PropertyType == typeof(T));
        }
    }
}