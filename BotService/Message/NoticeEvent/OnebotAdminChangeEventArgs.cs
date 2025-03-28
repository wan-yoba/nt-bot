using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration.EventParamsType;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 群管理员变动事件
/// </summary>
public sealed class OnebotAdminChangeEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 事件子类型
    /// </summary>
    [JsonConverter(typeof(EnumAdminChangeDescriptionConverter))]
    [JsonPropertyName("sub_type")]
    public AdminChangeType SubType { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}