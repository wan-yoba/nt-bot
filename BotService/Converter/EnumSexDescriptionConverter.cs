using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using BotService.Enumeration;

namespace BotService.Converter;

/// <summary>
/// sex converter
/// </summary>
public class EnumSexDescriptionConverter : JsonConverter<Sex>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(Sex);
    }

    public override Sex Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readValue = reader.GetString() ?? string.Empty;

        // 获取枚举类型的所有字段
        var fields = typeToConvert.GetFields();

        foreach (var field in typeof(Sex).GetFields())
        {
            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null && descriptionAttribute.Description == readValue)
            {
                return (Sex)field.GetValue(null)!;
            }
        }

        return Sex.Unknown;
    }

    public override void Write(Utf8JsonWriter writer, Sex value, JsonSerializerOptions options)
    {
        // 获取枚举的描述值
        var description = (value.GetType()
                .GetField(value.ToString()) ?? throw new InvalidOperationException())
            .GetCustomAttribute<DescriptionAttribute>()
            ?.Description;

        writer.WriteStringValue(description ?? value.ToString());
    }
}