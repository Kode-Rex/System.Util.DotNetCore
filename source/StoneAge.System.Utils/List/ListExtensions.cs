using System;
using System.Collections.Generic;
using System.Text;

namespace StoneAge.System.Utils
{
    public static class ListExtensions
    {
        public static IEnumerable<List<T>> Split_List<T>(this List<T> data, int chunkSize = 10)
        {
            for (int i = 0; i < data.Count; i += chunkSize)
            {
                yield return data.GetRange(i, Math.Min(chunkSize, data.Count - i));
            }
        }
    }
}
