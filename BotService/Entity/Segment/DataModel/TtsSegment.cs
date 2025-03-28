using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 语音转文字（TTS）
/// </summary>
[ProtoContract]
public sealed record TtsSegment : BaseSegment
{
    /// <summary>
    /// 纯文本内容
    /// </summary>
    [JsonPropertyName("text")]
    [ProtoMember(1)]
    public string Content { get; set; }
}