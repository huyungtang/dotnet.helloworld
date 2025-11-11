using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnet.Providers
{
  public class JsonDatetimeOffsetProvider : JsonConverter<DateTimeOffset>
  {
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      return reader.GetDateTimeOffset();
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
      writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
    }
  }
}
