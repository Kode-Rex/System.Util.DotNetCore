using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StoneAge.System.Utils.Equivalent
{
    public static class ObjectEquivalence
    {
        public static bool EquivalentTo<T>(this T instance1, T instance2) where T : class
        {
            return AreObjectsEquivalent(instance1, instance2, new string[0]);
        }

        public static bool EquivalentTo<T>(this T instance1, T instance2, string[] ignoredFields) where T : class
        {
            return AreObjectsEquivalent(instance1, instance2, ignoredFields);
        }

        private static bool AreObjectsEquivalent<T>(T instance1, T instance2, string[] ignoredFields)
        {
            var props = new List<PropertyInfo>(typeof(T).GetProperties());

            foreach (var prop in props)
            {
                if (ignoredFields.Contains(prop.Name)) continue;

                var propValue1 = prop.GetValue(instance1, null);
                var propValue2 = prop.GetValue(instance2, null);

                if(propValue1 == null && propValue2 == null) continue;
                if(propValue1.ToString().TrimEnd('0') != propValue2.ToString().TrimEnd('0'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
