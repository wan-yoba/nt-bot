using System.Text.Json.Serialization;
using BotService.Entity;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 消息事件基类
/// </summary>
public abstract class BaseObNoticeEventArgs : BaseObApiEventArgs
{
    /// <summary>
    /// 消息类型
    /// </summary>
   [JsonPropertyName("notice_type")]
    public string NoticeType { get; set; }

    /// <summary>
    /// 操作对象UID
    /// </summary>
   [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}