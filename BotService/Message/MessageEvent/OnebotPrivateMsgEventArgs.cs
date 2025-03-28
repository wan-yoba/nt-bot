using System.Text.Json.Serialization;
using BotService.Entity;

namespace BotService.Message.MessageEvent;

/// <summary>
/// 私聊消息事件
/// </summary>
public sealed class OnebotPrivateMsgEventArgs : BaseObMessageEventArgs
{
    /// <summary>
    /// 发送人信息
    /// </summary>
    [JsonPropertyName("sender")]
    public PrivateSenderInfo SenderInfo { get; set; }
}