using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace StoneAge.System.Utils.Hash
{
    public static class ObjectPropertyHash
    {
        private static readonly IEnumerable<string> AllProperties = null;

        public static string Calculate_Hash<T>(this T instance)
        {
            var propertyString = Concat_Properites(instance, AllProperties);

            return Calculate_Hash(propertyString);
        }

        private static string Calculate_Hash(string propertyString)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(propertyString));

                return Convert_Bytes_To_String(bytes);
            }
        }

        private static string Convert_Bytes_To_String(byte[] bytes)
        {
            var builder = new StringBuilder();
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }
            return builder.ToString();
        }

        private static string Concat_Properites<T>(T instance, IEnumerable<string> propertyNamesToMatch)
        {
            var props = List_Properites<T>();
            var result = new StringBuilder();

            foreach (var prop in props)
            {
                if (Property_In_List(propertyNamesToMatch, prop))
                {
                    var propValue = prop.GetValue(instance, null);
                    result.Append(propValue);
                }
            }

            return result.ToString();
        }

        private static bool Property_In_List(IEnumerable<string> matchingProperites, PropertyInfo prop)
        {
            return Equals(matchingProperites, AllProperties) || matchingProperites.Contains(prop.Name);
        }

        private static List<PropertyInfo> List_Properites<T>()
        {
            var properties = typeof(T).GetProperties();
            var orderedProperties = properties.OrderBy(x => x.Name);
            var result = new List<PropertyInfo>(orderedProperties);
            return result;
        }
    }
}
