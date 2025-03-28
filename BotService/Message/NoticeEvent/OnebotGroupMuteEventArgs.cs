using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration.EventParamsType;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 群禁言事件
/// </summary>
public sealed class OnebotGroupMuteEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 事件子类型
    /// </summary>
    [JsonConverter(typeof(EnumMuteActionDescriptionConverter))]
    [JsonPropertyName("sub_type")]
    public MuteActionType ActionType { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 操作者 UID
    /// </summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }

    /// <summary>
    /// 禁言时长(s)
    /// </summary>
    [JsonPropertyName("duration")]
    public long Duration { get; set; }
}