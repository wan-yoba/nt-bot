using System;
using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 自定义回复
/// </summary>
[ProtoContract]
public sealed record CustomReplySegment : BaseSegment
{
    /// <summary>
    /// 自定义回复的信息
    /// </summary>
    [JsonPropertyName("text")]
    [ProtoMember(1)]
    public string Text { get; set; }

    /// <summary>
    /// 自定义回复时的自定义QQ
    /// </summary>
    [JsonPropertyName("qq")]
    [ProtoMember(2)]
    public long Uid { get; set; }

    [JsonPropertyName("time")]
    [ProtoMember(3)]
    private long TimeStamp { get; set; }

    /// <summary>
    /// 自定义回复时的时间
    /// </summary>
    [JsonIgnore]
    public DateTime Time
    {
        get => TimeStamp.ToDateTime();
        init => TimeStamp = value.ToTimeStamp();
    }

    /// <summary>
    /// 起始消息序号, 可通过 <see langword="GetMessages"/> 获得
    /// </summary>
    [JsonPropertyName("seq")]
    [ProtoMember(4)]
    public long MessageSequence { get; set; }
}