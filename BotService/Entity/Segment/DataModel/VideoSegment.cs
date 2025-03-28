using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 短视频
/// </summary>
[ProtoContract]
public sealed record VideoSegment : BaseSegment
{
    /// <summary>
    /// 视频文件名
    /// </summary>
    [JsonPropertyName("file")]
    [ProtoMember(1)]
    public string VideoFile { get; set; }

    /// <summary>
    /// 视频 URL
    /// </summary>
    [JsonPropertyName("url")]
    [ProtoMember(2)]
    public string Url { get; set; }

    /// <summary>
    /// 是否使用已缓存的文件
    /// </summary>
    [JsonPropertyName("cache")]
    [ProtoMember(3)]
    public int? Cache { get; set; }

    /// <summary>
    /// 是否使用已缓存的文件
    /// </summary>
    [JsonPropertyName("proxy")]
    [ProtoMember(4)]
    public int? Proxy { get; set; }

    /// <summary>
    /// 是否使用已缓存的文件
    /// </summary>
    [JsonPropertyName("timeout")]
    [ProtoMember(5)]
    public int? Timeout { get; set; }
}