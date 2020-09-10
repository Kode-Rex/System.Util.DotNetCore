using System.Linq;
using System.Reflection;

namespace StoneAge.System.Utils.Extract
{
    public static class ObjectValueExtractor
    {
        public static T ExtractField<T>(this object instance1, string fieldName)
        {
            var fields = instance1.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
            var field = fields.FirstOrDefault(x=>x.Name == fieldName);

            if(field == null)
            {
                return default(T);
            }

            var value = field.GetValue(instance1);

            return (T)value;
        }
    }
}
