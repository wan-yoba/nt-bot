using System.ComponentModel;
using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// At某人
/// </summary>
[ProtoContract]
public sealed record AtSegment : BaseSegment
{
    /// <summary>
    /// At目标UID
    /// 为<see langword="all"/>时为At全体
    /// </summary>
    [JsonPropertyName("qq")]
    [ProtoMember(1)]
    public string Target { get; set; }

    /// <summary>
    /// 覆盖被AT用户的用户名
    /// </summary>
    [JsonPropertyName("name")]
    [ProtoMember(2)]
    public string Name { get; set; }
}