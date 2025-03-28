using System.ComponentModel;
using System.Text.Json.Serialization;
using BotService.Converter;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// QQ 表情
/// </summary>
[ProtoContract]
public sealed record FaceSegment : BaseSegment
{
    /// <summary>
    /// 纯文本内容
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("id")]
    [ProtoMember(1)]
    public int Id { get; set; }
}