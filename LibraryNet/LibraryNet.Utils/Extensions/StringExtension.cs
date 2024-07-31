namespace LibraryNet.Utils.Extensions
{
    public static class StringExtension
    {
        public static bool CleanNullWhite(this string s) => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        
        public static bool CleanNullWhiteOrZero(this string s) => s.CleanNullWhite() || s == "0";
    }
}