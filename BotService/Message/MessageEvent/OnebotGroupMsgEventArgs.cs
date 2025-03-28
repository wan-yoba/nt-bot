using System.Text.Json.Serialization;
using BotService.Entity;
using BotService.Message.MessageEvent;

namespace Sora.OnebotModel.OnebotEvent.MessageEvent;

/// <summary>
/// 群组消息事件
/// </summary>
public sealed class OnebotGroupMsgEventArgs : BaseObMessageEventArgs
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 匿名信息
    /// </summary>
    [JsonPropertyName("anonymous")]
    public Anonymous Anonymous { get; set; }

    /// <summary>
    /// 发送人信息
    /// </summary>
    [JsonPropertyName("sender")]
    public GroupSenderInfo SenderInfo { get; set; }

    /// <summary>
    /// 消息序号
    /// </summary>
    [JsonPropertyName("message_seq")]
    public long MessageSequence { get; set; }
}