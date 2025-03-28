using System.Text.Json.Serialization;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 群消息撤回事件
/// </summary>
public sealed class ApiGroupRecallEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 操作者 QQ 号
    /// </summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }

    /// <summary>
    /// 被撤回的消息 ID
    /// </summary>
    [JsonPropertyName("message_id")]
    public int MessageId { get; set; }
}