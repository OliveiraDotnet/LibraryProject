using AutoMapper;
using LibraryNet.Utils.DependencyInjection;

namespace LibraryNet.Utils.Extensions
{
    public static class TypeExtension
    {
        public static T Inject<T, D>(this T obj, D complement) => DependencyManager.Instance.GetInstance<IMapper>().Map(complement, obj);

        public static T Like<T>(this object obj, bool notMapper = false, bool allowException = false, T defaultValue = default)
        {
            try
            {
                if (obj == null)
                    return defaultValue;

                if (obj.GetType() == typeof(T))
                    return (T)obj;

                if (obj is Enum)
                {
                    if (typeof(T) == typeof(int) || typeof(T) == typeof(byte) || typeof(T) == typeof(Enum) || typeof(T) == typeof(long) || typeof(T) == typeof(short))
                        return (T)obj;

                    if (defaultValue.Equals(default(T)))
                        return ConvertExtension.AwaysConvertEnum<T>(obj);
                    return ConvertExtension.AwaysConvertEnum(obj, defaultValue);
                }

                if (!notMapper)
                    return DependencyManager.Instance.GetInstance<IMapper>().Map<T>(obj);

                return (T)obj;
            }
            catch (Exception)
            {
                if (allowException)
                    throw;

                return default;
            }
        }
    }
}