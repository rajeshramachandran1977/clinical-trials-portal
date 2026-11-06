using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace Anju.Navigate.Utilities
{  
    public static class EnumExtension
    {
        public static string ToId<T>(this T source) where T : IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return ((int)(IConvertible)source).ToString();
        }

        public static string DisplayName(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        public static string FirstChar(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            return enumValue.Substring(0, 1);
        }
    }
}
