using System.ComponentModel;
using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// <para>Xml与Json集合</para>
/// <para>可能为<see cref="SegmentType.Json"/>或<see cref="SegmentType.Xml"/></para>
/// </summary>
[ProtoContract]
public sealed record CodeSegment : BaseSegment
{
    /// <summary>
    /// 内容
    /// </summary>
    [JsonPropertyName("data")]
    [ProtoMember(1)]
    public string Content { get; set; }

    /// <summary>
    /// 是否走富文本通道
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("resid")]
    [ProtoMember(2)]
    public int? Resid { get; set; }
}