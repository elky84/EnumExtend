using System;
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

        public static string GetEnumDescription(object value)
        {
            if (value == null)
                return null;

            Type type = value.GetType();
            if (!type.IsEnum)
                throw new ApplicationException("Value parameter must be an enum.");

            FieldInfo fieldInfo = type.GetField(value.ToString());
            object[] descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptionAttributes == null || descriptionAttributes.Length == 0)
            {
                object[] enforcementAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptiveEnumEnforcementAttribute), false);
                if (enforcementAttributes != null && enforcementAttributes.Length == 1)
                {
                    DescriptiveEnumEnforcementAttribute enforcementAttribute = (DescriptiveEnumEnforcementAttribute)enforcementAttributes[0];

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

        public static T ToEnumString<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
