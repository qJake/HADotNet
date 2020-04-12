using Newtonsoft.Json;
using System;

namespace HADotNet.Core.Utility
{
    /// <summary>
    /// Deserializes the "Example" field into a string regardless of its type.
    /// </summary>
    public class ServiceExampleDeserializer : JsonConverter
    {
        /// <summary>
        /// Always attempt to deserialize examples.
        /// </summary>
        public override bool CanConvert(Type objType) => true;

        /// <summary>
        /// Read the JSON into a string.
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject || reader.TokenType == JsonToken.StartArray)
            {
                return JsonSerializer.CreateDefault().Deserialize(reader).ToString();
            }
            else
            {
                return reader.Value?.ToString();
            }
        }

        /// <summary>
        /// Read-only, no writing.
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }
    }
}
