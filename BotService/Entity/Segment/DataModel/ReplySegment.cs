using System.ComponentModel;
using System.Text.Json.Serialization;
using BotService.Converter;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 回复
/// </summary>
[ProtoContract]
public sealed record ReplySegment : BaseSegment
{
    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("id")]
    [ProtoMember(1)]
    public int Target { get; set; }
}