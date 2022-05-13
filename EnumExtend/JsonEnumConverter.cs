using Newtonsoft.Json;
using System;

namespace EnumExtend
{
    public class JsonEnumConverter<T> : JsonConverter where T : struct, IComparable, IConvertible, IFormattable
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                Enum sourceEnum = value as Enum;

                if (sourceEnum != null)
                {
                    string enumText = sourceEnum.GetDescription();
                    writer.WriteValue(enumText);
                }
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            object val = reader.Value;

            if (val != null)
            {
                var enumString = (string)reader.Value;

                return EnumUtil.FromDescription<T>(enumString);
            }

            return null;
        }
    }
}