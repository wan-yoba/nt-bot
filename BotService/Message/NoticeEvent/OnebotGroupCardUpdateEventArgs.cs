using System.Text.Json.Serialization;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// GoCQ扩展事件
/// 群成员名片变更事件
/// </summary>
public sealed class OnebotGroupCardUpdateEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 新名片
    /// </summary>
    [JsonPropertyName("card_new")]
    public string NewCard { get; set; }

    /// <summary>
    /// 旧名片
    /// </summary>
    [JsonPropertyName("card_old")]
    public string OldCard { get; set; }
}