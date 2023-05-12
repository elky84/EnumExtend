using System;

namespace EnumExtend
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DescriptionAttribute : System.Attribute
    {
        private string Description { get; set; }

        public DescriptionAttribute() { }

        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
