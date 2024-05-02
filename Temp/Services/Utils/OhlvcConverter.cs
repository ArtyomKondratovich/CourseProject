using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Temp.Services.Models;

namespace Temp.Services.Utils
{
    public class OhlvcConverter : JsonConverter<Ohlvc>
    {
        public override Ohlvc Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var financialData = new Ohlvc();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        return financialData;
                    }

                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        var propertyName = reader.GetString();
                        reader.Read();

                        switch (propertyName)
                        {
                            case "open":
                                financialData.Open = double.Parse(reader.GetString());
                                break;
                            case "close":
                                financialData.Close = double.Parse(reader.GetString());
                                break;
                            case "volume":
                                financialData.Volume = double.Parse(reader.GetString());
                                break;
                            case "high":
                                financialData.High = double.Parse(reader.GetString());
                                break;
                            case "low":
                                financialData.Low = double.Parse(reader.GetString());
                                break;
                        }
                    }
                }

                return financialData;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, Ohlvc value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
