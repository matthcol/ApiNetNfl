
using ApiNFL.Enumeration;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiNFL.Shared
{
    public class JsonConferenceEnumConverter : JsonConverter<ConferenceEnum>
    {
        public override ConferenceEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // TODO: throw wright exception(Invalid Format)
            return Enum.Parse<ConferenceEnum>(reader.GetString(),true);
        }

        public override void Write(Utf8JsonWriter writer, ConferenceEnum value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToLower());
        }
    }
}
