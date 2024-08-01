using System.Text.RegularExpressions;

namespace LibraryNet.Utils.Extensions
{
    public static class StringExtension
    {
        public static string CamelCaseParaNormal(this string str) => string.IsNullOrEmpty(str) ? str : Regex.Replace(str, "([A-Z])", " $1").Trim();
        public static bool CleanNullWhite(this string s) => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        public static bool CleanNullWhiteOrZero(this string s) => s.CleanNullWhite() || s == "0";
    }
}