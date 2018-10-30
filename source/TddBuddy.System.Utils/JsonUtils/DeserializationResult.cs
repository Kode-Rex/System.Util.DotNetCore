using System.Collections.Generic;

namespace TddBuddy.System.Utils.JsonUtils
{
    public class DeserializationResult<T>
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; }
        public T ParsedModel { get; set; }

        public DeserializationResult()
        {
            Errors = new List<string>();
        }
    }
}