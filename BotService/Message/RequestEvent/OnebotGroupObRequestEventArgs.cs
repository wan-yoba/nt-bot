using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration.EventParamsType;

namespace BotService.Message.RequestEvent;

/// <summary>
/// 群聊邀请/入群请求事件
/// </summary>
public sealed class OnebotGroupObRequestEventArgs : BaseObRequestEvent
{
    /// <summary>
    /// 请求子类型
    /// </summary>
    [JsonConverter(typeof(EnumGroupRequestDescriptionConverter))]
    [JsonPropertyName("sub_type")]
    public GroupRequestType GroupRequestType { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 邀请者ID
    /// </summary>
    [JsonPropertyName("invitor_id")]
    public long InvitorId { get; set; }
}