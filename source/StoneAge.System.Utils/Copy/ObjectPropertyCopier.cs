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

        public static void CopyPropertiesTo<T>(this T instance1, T instance2, string[] ignoredProperties) where T : class
        {
            CopyProperties(instance1, instance2, ignoredProperties);
        }

        private static void CopyProperties<T>(T instance1, T instance2, string[] ignoredProperties)
        {
            var props = new List<PropertyInfo>(typeof(T).GetProperties());

            Throw_Exception_On_Unmatched_IgnoredProperties<T>(ignoredProperties, props);

            foreach (var prop in props)
            {
                if (ignoredProperties.Contains(prop.Name)) continue;

                var propValue = prop.GetValue(instance1, null);
                prop.SetValue(instance2, propValue);
            }
        }

        private static void Throw_Exception_On_Unmatched_IgnoredProperties<T>(string[] ignoredFields, List<PropertyInfo> props)
        {
            var propertyNames = props.Select(x => x.Name);
            var notFoundIgnoredFields = ignoredFields.Where(x => propertyNames.All(y => y != x)).ToList();
            if (!notFoundIgnoredFields.Any()) return;
            
            var missingPropertyList = string.Join(',', notFoundIgnoredFields);
            var propertyWord = "property";
            if (notFoundIgnoredFields.Count > 1)
            {
                propertyWord = "properties";
            }
            throw new ObjectPropertyMissingException(
                $"Ignored {propertyWord} [{missingPropertyList}] is not found on object. Property names are case sensitive.");
        }
    }
}
