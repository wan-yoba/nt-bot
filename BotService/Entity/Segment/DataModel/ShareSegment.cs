using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 链接分享
/// </summary>
[ProtoContract]
public sealed record ShareSegment : BaseSegment
{
    /// <summary>
    /// URL
    /// </summary>
    [JsonPropertyName("url")]
    [ProtoMember(1)]
    public string Url { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName("title")]
    [ProtoMember(2)]
    public string Title { get; set; }

    /// <summary>
    /// 可选，内容描述
    /// </summary>
    [JsonPropertyName("content")]
    [ProtoMember(3)]
    public string Content { get; set; }

    /// <summary>
    /// 可选，图片 URL
    /// </summary>
    [JsonPropertyName("image")]
    [ProtoMember(4)]
    public string ImageUrl { get; set; }
}