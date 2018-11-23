using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StoneAge.System.Utils.Copy
{
    public static class ObjectPropertyCopier
    {
        public static void CopyPropertiesTo<T>(this T instance1, T instance2) where T : class
        {
            CopyProperties(instance1, instance2, new string[0]);
        }

        public static void CopyPropertiesTo<T>(this T instance1, T instance2, string[] ignoredFields) where T : class
        {
            CopyProperties(instance1, instance2, ignoredFields);
        }

        private static void CopyProperties<T>(T instance1, T instance2, string[] ignoredFields)
        {
            var props = new List<PropertyInfo>(typeof(T).GetProperties());

            foreach (var prop in props)
            {
                if (ignoredFields.Contains(prop.Name)) continue;

                var propValue = prop.GetValue(instance1, null);
                prop.SetValue(instance2, propValue);
            }
        }
    }
}
