using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BotService.Converter;

/// <summary>
/// onebot 转string
/// </summary>
public class OneBotIntConverter : JsonConverter<int>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(int);
    }

    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                // 将 string 转换为 int
                return int.Parse(reader.GetString() ?? string.Empty);
            case JsonTokenType.Number:
                // 如果是数字类型，直接转换为 int
                return reader.GetInt32();
            default: return 0;
        }
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}