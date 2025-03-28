using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration;
using BotService.Enumeration.EventParamsType;

namespace BotService.Entity;

/// <summary>
/// 私聊消息发送者
/// </summary>
public struct PrivateSenderInfo
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
    /// <para>来源群号</para>
    /// <para>仅支持GoCQ</para>
    /// </summary>
    [JsonPropertyName("group_id")]
    public long? GroupId { get; init; }

    /// <summary>
    /// 权限等级
    /// </summary>
    [JsonIgnore]
    public MemberRoleType Role { get; set; }
}