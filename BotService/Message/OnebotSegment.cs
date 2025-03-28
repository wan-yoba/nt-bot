using System.Text.Json;
using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration;

namespace BotService.Message;

/// <summary>
/// Onebot消息段
/// </summary>
public readonly struct OnebotSegment
{
    /// <summary>
    /// 消息段类型
    /// </summary>
    [JsonConverter(typeof(EnumSegmentTypeDescriptionConverter))]
    [JsonPropertyName("type")]
    public SegmentType MsgType { get; init; }

    /// <summary>
    /// 消息段JSON
    /// </summary>
    [JsonPropertyName("data")]
    public object RawData { get; init; }

    /// <summary>
    /// 消息段JSON
    /// </summary>
    public string RawDataJson => JsonSerializer.Serialize(RawData);
}