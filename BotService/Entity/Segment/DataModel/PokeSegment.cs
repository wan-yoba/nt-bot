using System.ComponentModel;
using System.Text.Json.Serialization;
using BotService.Converter;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// <para>群成员戳一戳</para>
/// <para>仅发送</para>
/// <para>仅支持GoCQ</para>
/// </summary>
[ProtoContract]
public sealed record PokeSegment : BaseSegment
{
    /// <summary>
    /// 需要戳的成员
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("qq")]
    [ProtoMember(1)]
    public long Uid { get; set; }
}