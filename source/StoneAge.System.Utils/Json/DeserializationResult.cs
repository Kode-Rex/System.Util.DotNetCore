using System.Collections.Generic;

namespace StoneAge.System.Utils.Json
{
    public class DeserializationResult<T>
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; }
        public T Model { get; set; }

        public DeserializationResult()
        {
            Errors = new List<string>();
        }
    }
}