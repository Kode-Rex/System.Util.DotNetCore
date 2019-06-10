using System;
using System.Collections.Generic;
using System.Text;

namespace StoneAge.System.Utils.Copy
{
    public class ObjectPropertyMissingException : Exception
    {
        public ObjectPropertyMissingException(string message) : base(message)
        {
        }
    }
}
