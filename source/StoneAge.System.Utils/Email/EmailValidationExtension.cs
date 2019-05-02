using System.Text.RegularExpressions;

namespace StoneAge.System.Utils.Email
{
    public static class EmailValidationExtension
    {
        public static bool Is_Valid_Email(this string input)
        {
            var emailValidationRegex = CreateValidEmailRegex();
            return emailValidationRegex.IsMatch(input);
        }

        private static Regex CreateValidEmailRegex()
        {
            var validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
    }
}
