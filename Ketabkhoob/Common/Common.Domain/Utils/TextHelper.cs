using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Domain.Utils
{
    public static class TextHelper
    {
        public static bool IsText(this string value)
        {
            var isNumber = Regex.IsMatch(value, Constants.RegexExpressions.IS_NUMBER);
            return !isNumber;
        }
        public static string SetUnReadableEmail(this string email)
        {
            email = email.Split('@')[0];
            var emailLength = email.Length;
            email = Constants.SPREAD+email.Substring(0, emailLength-1);
            return email;
        }

        public static string ToSlug(this string url)
        {
            return url.Trim().ToLower()
                .Replace(Constants.DOLLAR_SIGN, string.Empty)
                .Replace(Constants.PLUS, string.Empty)
                .Replace(Constants.PERCENT, string.Empty)
                .Replace(Constants.QUESTION_MARK, string.Empty)
                .Replace(Constants.CIRCUMFLEX_SIGN, string.Empty)
                .Replace(Constants.STAR_SIGN, string.Empty)
                .Replace(Constants.AND_SIGN, string.Empty)
                .Replace(Constants.EXCLAMATION_MARK, string.Empty)
                .Replace(Constants.HASH_TAG, string.Empty)
                .Replace(Constants.AND_SIGN, string.Empty)
                .Replace(Constants.TILDE_SIGGN, string.Empty)
                .Replace(Constants.OPEN_PRANTHESIS, string.Empty)
                .Replace(Constants.EQUAL_SIGN, string.Empty)
                .Replace(Constants.CLOSE_PRANTHESIS, string.Empty)
                .Replace(Constants.SLASH_SIGN, string.Empty)
                .Replace(Constants.BACK_SLASH_SIGN, string.Empty)
                .Replace(Constants.DOT, string.Empty)
                .Replace(Constants.SPACE,Constants.HYPHEN);
        }
    }
}
