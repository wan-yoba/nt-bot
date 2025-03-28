using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration;
using BotService.Enumeration.EventParamsType;

namespace BotService.Entity;

/// <summary>
/// 群组消息发送者
/// </summary>
public struct GroupSenderInfo
{
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nick { get; init; }

    /// <summary>
    /// 群名片/备注
    /// </summary>
    [JsonPropertyName("card")]
    public string Card { get; init; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonPropertyName("sex")]
    [JsonConverter(typeof(EnumSexDescriptionConverter))]
    public Sex Sex { get; init; }

    /// <summary>
    /// 年龄
    /// </summary>
    [JsonPropertyName("age")]
    public int Age { get; init; }

    /// <summary>
    /// 地区
    /// </summary>
    [JsonPropertyName("area")]
    public string Area { get; init; }

    /// <summary>
    /// 成员等级
    /// </summary>
    [JsonPropertyName("level")]
    public string Level { get; init; }

    /// <summary>
    /// 角色(权限等级)
    /// </summary>
    [JsonConverter(typeof(EnumMemberRoleDescriptionConverter))]
    [JsonPropertyName("role")]
    public MemberRoleType Role { get; set; }

    /// <summary>
    /// 专属头衔
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; init; }
}