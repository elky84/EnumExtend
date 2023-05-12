using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnumExtend
{
    public static partial class EnumUtil
    {
        public static string GetDescription(this Enum value)
        {
            return GetEnumDescription(value);
        }

        public static string Desc(this Enum value)
        {
            return GetEnumDescription(value);
        }

        public static string GetDescription<T>(object value)
        {
            return GetEnumDescription(value);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static string GetEnumDescription(object value)
        {
            if (value == null)
                return null;

            var type = value.GetType();
            if (!type.IsEnum)
                throw new ApplicationException("Value parameter must be an enum.");

            var fieldInfo = type.GetField(value.ToString());
            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes.Length == 0)
            {
                var enforcementAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptiveEnumEnforcementAttribute), false);
                if (enforcementAttributes.Length == 1)
                {
                    var enforcementAttribute = (DescriptiveEnumEnforcementAttribute)enforcementAttributes[0];

                    if (enforcementAttribute.EnforcementType == DescriptiveEnumEnforcementAttribute.EnforcementTypeEnum.ThrowException)
                        throw new ApplicationException("No Description attributes exist in enforced enum of type '" + type.Name + "', value '" + value.ToString() + "'.");

                    return value.ToString();
                }
                else
                    return value.ToString();
            }
            else if (descriptionAttributes.Length > 1)
                throw new ApplicationException("Too many Description attributes exist in enum of type '" + type.Name + "', value '" + value.ToString() + "'.");

            return descriptionAttributes[0].ToString();
        }

        public static T FromString<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static List<T> GetEnumList<T>()
        {
            return ((T[])Enum.GetValues(typeof(T))).ToList();
        }

        public static List<T> FromDescriptions<T>(List<string> descriptions) where T : struct
        {
            return descriptions.ConvertAll(FromDescription<T>).ToList();
        }

        public static T FromDescription<T>(string description) where T : struct
        {
            foreach (var e in (T[])Enum.GetValues(typeof(T)))
            {
                var eValue = (Enum)Enum.ToObject(typeof(T), e);
                if (eValue.GetDescription() == description)
                {
                    return e;
                }
            }

            return default;
        }
    }
}
