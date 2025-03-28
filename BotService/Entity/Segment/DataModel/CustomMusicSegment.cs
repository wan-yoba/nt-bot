
using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 自定义音乐分享
/// </summary>
[ProtoContract]
public sealed record CustomMusicSegment : BaseSegment
{
    [JsonPropertyName("type")]
    [ProtoMember(1)]
    public string ShareType;

    /// <summary>
    /// 跳转URL
    /// </summary>
    [JsonPropertyName("url")]
    [ProtoMember(2)]
    public string Url { get; set; }

    /// <summary>
    /// 音乐URL
    /// </summary>
    [JsonPropertyName("audio")]
    [ProtoMember(3)]
    public string MusicUrl { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonPropertyName("title")]
    [ProtoMember(4)]
    public string Title { get; set; }

    /// <summary>
    /// 内容描述[可选]
    /// </summary>
    [JsonPropertyName("content")]
    [ProtoMember(5)]
    public string Content { get; set; }

    /// <summary>
    /// 分享内容图片[可选]
    /// </summary>
    [JsonPropertyName("image")]
    [ProtoMember(6)]
    public string CoverImageUrl { get; set; }
}