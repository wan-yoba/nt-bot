using System.ComponentModel;
using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration.EventParamsType;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 音乐分享
/// 仅发送
/// </summary>
[ProtoContract]
public sealed record MusicSegment : BaseSegment
{
    /// <summary>
    /// 音乐分享类型
    /// </summary>
    [JsonConverter(typeof(EnumMusicShareDescriptionConverter))]
    [JsonPropertyName("type")]
    [ProtoMember(1)]
    public MusicShareType MusicType { get; set; }

    /// <summary>
    /// 歌曲 ID
    /// </summary>
    [JsonConverter(typeof(OneBotIntConverter))]
    [JsonPropertyName("id")]
    [ProtoMember(2)]
    public long MusicId { get; set; }
}