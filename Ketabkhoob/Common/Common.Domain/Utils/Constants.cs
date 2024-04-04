using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Utils
{
    public static class Constants
    {
        public static class RegexExpressions
        {
            public static string IS_NUMBER = @"^\d+$";
        }
        public static class Exceptions
        {
            public static string DUPLICATED_SLUG => "Slug is duplicated";
        }
        public static string SPREAD => "...";
        public static string DOLLAR_SIGN =>"$";
        public static string PLUS => "+";
        public static string PERCENT => "%";
        public static string QUESTION_MARK => "?";
        public static string CIRCUMFLEX_SIGN => "^";
        public static string STAR_SIGN => "*";
        public static string AT_SIGN => "@";
        public static string EXCLAMATION_MARK => "!";
        public static string HASH_TAG => "#";
        public static string AND_SIGN => "&";
        public static string TILDE_SIGGN => "~";
        public static string BACK_TICK => "`";
        public static string OPEN_PRANTHESIS => "(";
        public static string CLOSE_PRANTHESIS => ")";
        public static string EQUAL_SIGN => "=";
        public static string GT_SIGN => ">";
        public static string LT_SIGN => "<";
        public static string SLASH_SIGN => "/";
        public static string BACK_SLASH_SIGN => @"\";

        public static string SPACE => " ";
        public static string HYPHEN => "-";

        public static string DOT = ".";

    }
}
