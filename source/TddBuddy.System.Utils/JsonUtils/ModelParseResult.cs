using System.Collections.Generic;

namespace TddBuddy.System.Utils.JsonUtils
{
    public class ModelParseResult<T>
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; private set; }
        public T ParsedModel { get; set; }

        public ModelParseResult()
        {
            Errors = new List<string>();
        }
    }
}