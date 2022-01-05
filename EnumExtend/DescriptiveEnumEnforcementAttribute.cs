using System;

namespace EnumExtend
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class DescriptiveEnumEnforcementAttribute : System.Attribute
    {
        public enum EnforcementTypeEnum
        {
            ThrowException,
            DefaultToValue
        }

        public EnforcementTypeEnum EnforcementType { get; set; }

        public DescriptiveEnumEnforcementAttribute()
        {
            this.EnforcementType = EnforcementTypeEnum.DefaultToValue;
        }

        public DescriptiveEnumEnforcementAttribute(EnforcementTypeEnum enforcementType)
        {
            this.EnforcementType = enforcementType;
        }
    }
}
