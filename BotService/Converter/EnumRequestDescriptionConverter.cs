using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using BotService.Enumeration;
using BotService.Enumeration.EventParamsType;

namespace BotService.Converter;

/// <summary>
/// MemberRoleType converter
/// </summary>
public class EnumRequestDescriptionConverter : JsonConverter<RequestType>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(RequestType);
    }

    public override RequestType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readValue = reader.GetString() ?? string.Empty;

        foreach (var field in typeof(RequestType).GetFields())
        {
            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null && descriptionAttribute.Description == readValue)
            {
                return (RequestType)field.GetValue(null)!;
            }
        }

        return RequestType.Unknown;
    }

    public override void Write(Utf8JsonWriter writer, RequestType value, JsonSerializerOptions options)
    {
        // 获取枚举的描述值
        var description = (value.GetType()
                .GetField(value.ToString()) ?? throw new InvalidOperationException())
            .GetCustomAttribute<DescriptionAttribute>()
            ?.Description;

        writer.WriteStringValue(description ?? value.ToString());
    }
}