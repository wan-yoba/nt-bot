using System.Collections.Generic;
using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Entity;

namespace BotService.Message.MessageEvent;

/// <summary>
/// 消息事件基类
/// </summary>
public abstract class BaseObMessageEventArgs : BaseObApiEventArgs
{
    /// <summary>
    /// 消息类型
    /// </summary>
    [JsonPropertyName("message_type")]
    public string MessageType { get; set; }

    /// <summary>
    /// 消息子类型
    /// </summary>
    [JsonPropertyName("sub_type")]
    public string SubType { get; set; }

    /// <summary>
    /// 消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }

    /// <summary>
    /// 发送者UID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonPropertyName("message")]
    //[JsonConverter(typeof(OneBotMessageConverter))]
    public List<OnebotSegment> MessageList { get; set; }

    /// <summary>
    /// 原始消息内容
    /// </summary>
    [JsonPropertyName("raw_message")]
    public string RawMessage { get; set; }

    /// <summary>
    /// 字体
    /// </summary>
    [JsonPropertyName("font")]
    public int Font { get; set; }
}