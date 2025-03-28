using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration.EventParamsType;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 群成员变动事件
/// </summary>
public sealed class OnebotGroupMemberChangeEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 事件子类型
    /// </summary>
    [JsonConverter(typeof(EnumMemberRoleDescriptionConverter))]
    [JsonPropertyName("sub_type")]
    public MemberChangeType SubType { get; set; }

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
}