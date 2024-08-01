using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace LibraryNet.Utils.Extensions
{
    public static class EnumExtension
    {
        public static string Description(this Enum type)
        {
            if (type == null)
                return string.Empty;

            if (!type.GetType().HaveAnnotation<FlagsAttribute>())
                return GetEnumDescription(type);

            var sb = new StringBuilder();
            var values = Enum.GetValues(type.GetType());
            foreach (var e in values.Cast<Enum>().Where(type.HasFlag))
            {
                sb.Append(GetEnumDescription(e));
                sb.Append(",");
            }
            if (sb.Length > 0)
                sb.Length -= 1;
            return sb.ToString();
        }
        private static string GetEnumDescription(Enum tipo)
        {
            FieldInfo fieldInfo = tipo.GetType().GetRuntimeField(tipo.ToString());
            if (fieldInfo == null)
                return tipo.ToString().CamelCaseParaNormal();
            var atributo = fieldInfo.GetCustomAttribute<DisplayAttribute>();
            if (atributo != null)
                return atributo.Description;
            var nameAttribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            if (nameAttribute != null)
                return nameAttribute.Description;

            return tipo.ToString().CamelCaseParaNormal();
        }
        public static string EnumValueToString(this Enum tipo)
        {
            int value = Convert.ToInt32(tipo);
            return value.ToString();
        }
        public static int EnumValue(this Enum tipo)
        {
            return Convert.ToInt32(tipo);
        }
        public static IEnumerable KeyValueList(this Enum tipo)
        {
            var enumType = tipo.GetType();
            var values = Enum.GetValues(enumType);
            foreach (var e in values.Cast<Enum>().Where(tipo.HasFlag))
                yield return new KeyValuePair<string, string>(e.EnumValueToString(), e.Description());
        }
        public static List<T> GetValues<T>(this T value)
        {
            var likeEnum = value.Like<Enum>();
            var r = new List<T>();
            foreach (var v in Enum.GetValues(typeof(T)))
            {
                if (likeEnum.HasFlag(v.Like<Enum>()))
                    r.Add(v.Like<T>());
            }
            return r;
        }
    }
}