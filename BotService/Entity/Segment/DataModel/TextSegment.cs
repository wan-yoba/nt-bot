using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 纯文本
/// </summary>
[ProtoContract]
public sealed record TextSegment : BaseSegment
{
    /// <summary>
    /// 纯文本内容
    /// </summary>
    [JsonPropertyName("text")]
    [ProtoMember(1)]
    public string Content { get; set; }
}