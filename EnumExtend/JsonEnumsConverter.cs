using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumExtend
{
    public class JsonEnumsConverter<T> : JsonConverter where T : struct, IComparable, IConvertible, IFormattable
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch (value)
            {
                case null:
                    return;
                case Enum[] val:
                    writer.WriteValue(val.ToList().ConvertAll(x => x.GetDescription()).ToArray());
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return EnumUtil.FromDescriptions<T>(serializer.Deserialize<List<string>>(reader));
        }
    }
}