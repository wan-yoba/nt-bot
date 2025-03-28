using System.Text.Json.Serialization;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 好友消息撤回
/// </summary>
public sealed class OnebotFriendRecallEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 被撤回的消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }
}