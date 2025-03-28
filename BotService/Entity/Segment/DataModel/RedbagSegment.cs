using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 接收红包
/// 仅支持GoCQ
/// </summary>
[ProtoContract]
public sealed record RedbagSegment : BaseSegment
{
    /// <summary>
    /// 祝福语/口令
    /// </summary>
    [JsonPropertyName("title")]
    [ProtoMember(1)]
    public string Title { get; set; }
}