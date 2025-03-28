using System;
using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration;
using BotService.Enumeration.EventParamsType;

namespace BotService.Entity;

/// <summary>
/// 群成员信息
/// </summary>
public sealed record GroupMemberInfo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; init; }

    /// <summary>
    /// 成员UID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nick { get; init; }

    /// <summary>
    /// 群名片／备注
    /// </summary>
    [JsonPropertyName("card")]
    public string Card { get; init; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonPropertyName("sex")]
    private string SexStr { get; init; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonIgnore]
    public Sex Sex
    {
        get
        {
            return SexStr switch
            {
                "male" => Sex.Male,
                "female" => Sex.Female,
                _ => Sex.Unknown
            };
        }
    }

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
    /// 加群时间戳
    /// </summary>
    [JsonIgnore]
    public DateTime JoinTime { get; init; }

    [JsonPropertyName("join_time")]
    private long JoinTimeStamp
    {
        init => JoinTime = value.ToDateTime();
    }

    /// <summary>
    /// 最后发言时间戳
    /// </summary>
    [JsonIgnore]
    public DateTime LastSentTime { get; init; }

    [JsonPropertyName("last_sent_time")]
    private long LastSentTimeStamp
    {
        init => LastSentTime = value.ToDateTime();
    }

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
    public MemberRoleType Role { get; init; }

    /// <summary>
    /// 是否为机器人管理员
    /// </summary>
    [JsonIgnore]
    public bool IsSuperUser { get; set; } = false;

    /// <summary>
    /// 是否不良记录成员
    /// </summary>
    [JsonPropertyName("unfriendly")]
    public bool Unfriendly { get; init; }

    /// <summary>
    /// 专属头衔
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; init; }

    /// <summary>
    /// <para>专属头衔过期时间</para>
    /// <para>在<see cref="Title"/>不为空时有效</para>
    /// </summary>
    [JsonIgnore]
    public DateTime? TitleExpireTime { get; init; }

    [JsonPropertyName("title_expire_time")]
    private long? TitleExpireTimeStamp
    {
        init => TitleExpireTime = value == 0 ? null : value?.ToDateTime() ?? null;
    }

    /// <summary>
    /// 是否允许修改群名片
    /// </summary>
    [JsonPropertyName("card_changeable")]
    public bool CardChangeable { get; init; }

    /// <summary>
    /// 禁言截止时间
    /// </summary>
    [JsonIgnore]
    public DateTime? ShutUpTime { get; init; }

    [JsonPropertyName("shut_up_timestamp")]
    private long? ShutUpTimestamp
    {
        init => ShutUpTime = value == 0 ? null : value?.ToDateTime() ?? null;
    }
}