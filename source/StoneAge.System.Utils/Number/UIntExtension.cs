using System;
using System.Collections.Generic;
using System.Text;

namespace StoneAge.System.Utils.Number
{
    public static class UIntExtension
    {
        public static long ToInt(this uint value)
        {
            return Convert.ToInt32(value);
        }
    }
}
