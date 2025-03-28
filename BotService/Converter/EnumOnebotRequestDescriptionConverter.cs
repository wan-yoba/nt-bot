using System;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using BotService.Enumeration;
using BotService.Enumeration.ApiType;
using BotService.Enumeration.EventParamsType;

namespace BotService.Converter;

/// <summary>
/// ApiRequestType converter
/// </summary>
public class EnumOnebotRequestDescriptionConverter : JsonConverter<ApiRequestType>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(ApiRequestType);
    }

    public override ApiRequestType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readValue = reader.GetString() ?? string.Empty;

        foreach (var field in typeof(ApiRequestType).GetFields())
        {
            var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
            if (descriptionAttribute != null && descriptionAttribute.Description == readValue)
            {
                return (ApiRequestType)field.GetValue(null)!;
            }
        }

        return ApiRequestType.Unknown;
    }

    public override void Write(Utf8JsonWriter writer, ApiRequestType value, JsonSerializerOptions options)
    {
        // 获取枚举的描述值
        var description = (value.GetType()
                .GetField(value.ToString()) ?? throw new InvalidOperationException())
            .GetCustomAttribute<DescriptionAttribute>()
            ?.Description;

        writer.WriteStringValue(description ?? value.ToString());
    }
}