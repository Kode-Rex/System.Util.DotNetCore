using System;
using System.Collections.Generic;
using System.Text;

namespace StoneAge.System.Utils.Number
{
    public static class ULongExtension
    {
        public static long ToLong(this ulong value)
        {
            return Convert.ToInt64(value);
        }
    }
}
