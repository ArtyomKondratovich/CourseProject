using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Temp.Services.Utils
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var date = new DateTime();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        return date;
                    }

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        reader.Read();
                        date = reader.GetDateTime();
                    }
                }

                return date;
            }

            return new DateTime();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
