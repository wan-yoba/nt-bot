using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 合并转发/合并转发节点
/// </summary>
[ProtoContract]
public sealed record ForwardSegment : BaseSegment
{
    /// <summary>
    /// 转发消息ID
    /// </summary>
    [JsonPropertyName("id")]
    [ProtoMember(1)]
    public string MessageId { get; set; }
}