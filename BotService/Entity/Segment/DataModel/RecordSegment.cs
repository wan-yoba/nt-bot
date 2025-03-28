using System.ComponentModel;
using System.Text.Json.Serialization;
using BotService.Converter;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 语音消息
/// </summary>
[ProtoContract]
public sealed record RecordSegment : BaseSegment
{
    /// <summary>
    /// 文件名/绝对路径/URL/base64
    /// </summary>
    [JsonPropertyName("file")]
    [ProtoMember(1)]
    public string RecordFile { get; set; }

    /// <summary>
    /// 表示变声
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("magic")]
    [ProtoMember(2)]
    public int? Magic { get; set; }

    /// <summary>
    /// 语音 URL
    /// </summary>
    [JsonPropertyName("url")]
    [ProtoMember(3)]
    public string Url { get; set; }

    /// <summary>
    /// 是否使用已缓存的文件
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("cache")]
    [ProtoMember(4)]
    public int? Cache { get; set; }

    /// <summary>
    /// 是否使用代理
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("proxy")]
    [ProtoMember(5)]
    public int? Proxy { get; set; }

    /// <summary>
    /// 是否使用已缓存的文件
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("timeout")]
    [ProtoMember(6)]
    public int? Timeout { get; set; }
}