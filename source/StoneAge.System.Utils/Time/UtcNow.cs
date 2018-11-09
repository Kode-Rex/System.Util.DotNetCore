using System;

namespace StoneAge.System.Utils.Time
{
    public class UtcNow : INow
    {
        public DateTime Now()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
