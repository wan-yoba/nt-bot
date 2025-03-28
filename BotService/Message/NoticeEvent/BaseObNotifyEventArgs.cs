using System.Text.Json.Serialization;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 群内通知类事件
/// </summary>
public abstract class BaseObNotifyEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}