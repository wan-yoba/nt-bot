using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 装逼大图
/// 仅支持GoCQ
/// </summary>
[ProtoContract]
public sealed record CardImageSegment : BaseSegment
{

    /// <summary>
    /// 文件名/绝对路径/URL/base64
    /// </summary>
    [JsonPropertyName("file")]
    [ProtoMember(1)]
    public string ImageFile { get; set; }

    /// <summary>
    /// 最小width
    /// </summary>
    [JsonPropertyName("minwidth")]
    [ProtoMember(2)]
    public long MinWidth { get; set; }

    /// <summary>
    /// 最小height
    /// </summary>
    [JsonPropertyName("minheight")]
    [ProtoMember(3)]
    public long MinHeight { get; set; }

    /// <summary>
    /// 最大width
    /// </summary>
    [JsonPropertyName("maxwidth")]
    [ProtoMember(4)]
    public long MaxWidth { get; set; }

    /// <summary>
    /// 最大height
    /// </summary>
    [JsonPropertyName("maxheight")]
    [ProtoMember(5)]
    public long MaxHeight { get; set; }

    /// <summary>
    /// 来源名称
    /// </summary>
    [JsonPropertyName("source")]
    [ProtoMember(6)]
    public string Source { get; set; }

    /// <summary>
    /// 来源图标url
    /// </summary>
    [JsonPropertyName("icon")]
    [ProtoMember(7)]
    public string Icon { get; set; }
}