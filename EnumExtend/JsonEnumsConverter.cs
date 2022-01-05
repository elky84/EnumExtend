using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumExtend
{
    public class JsonEnumsConverter<T> : JsonConverter where T : IComparable, IConvertible, IFormattable
    {
        public static List<T> FromDescription(List<string> descriptions)
        {
            return descriptions.ConvertAll(x => FromDescription(x)).ToList();
        }

        public static T FromDescription(string description)
        {
            foreach (T e in (T[])Enum.GetValues(typeof(T)))
            {
                Enum eValue = (Enum)Enum.ToObject(typeof(T), e);
                if (eValue.GetDescription() == description)
                {
                    return e;
                }
            }

            return default;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                var val = value as Enum[];
                writer.WriteValue(val.ToList().ConvertAll(x => x.GetDescription()).ToArray());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return FromDescription(serializer.Deserialize<List<string>>(reader));
        }
    }
}