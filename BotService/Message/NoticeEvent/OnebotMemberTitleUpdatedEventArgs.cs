using System.Text.Json.Serialization;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 群成员头衔变更事件
/// </summary>
public sealed class OnebotMemberTitleUpdatedEventArgs : BaseObNotifyEventArgs
{
    /// <summary>
    /// 新头衔
    /// </summary>
    [JsonPropertyName("title")]
    public string NewTitle { get; set; }
}