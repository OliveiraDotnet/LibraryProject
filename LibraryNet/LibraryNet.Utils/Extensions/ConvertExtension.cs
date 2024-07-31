namespace LibraryNet.Utils.Extensions
{
    public static class ConvertExtension
    {
        public static T AwaysConvertEnum<T>(object vl, T defaultForNull = default)
        {
            try
            {
                var r = (T)Enum.Parse(typeof(T), vl.ToString(), true);
                return r;
            }
            catch (Exception)
            {
                return defaultForNull.Equals(default(T)) ? (T)Enum.GetValues(typeof(T)).GetValue(0) : defaultForNull;
            }
        }
    }
}