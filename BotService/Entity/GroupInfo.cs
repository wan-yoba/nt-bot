using System;
using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 群信息
/// </summary>
public readonly struct GroupInfo
{
    #region 属性

    /// <summary>
    /// 群名称
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; init; }

    /// <summary>
    /// 成员数
    /// </summary>
    [JsonPropertyName("member_count")]
    public int MemberCount { get; init; }

    /// <summary>
    /// 最大成员数（群容量）
    /// </summary>
    [JsonPropertyName("max_member_count")]
    public int MaxMemberCount { get; init; }

    /// <summary>
    /// 群组ID
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; init; }

    /// <summary>
    /// 群备注
    /// </summary>
    [JsonPropertyName("group_memo")]
    public string GroupMemo { get; init; }

    /// <summary>
    /// 群创建时间
    /// </summary>
    [JsonIgnore]
    public DateTime? GroupCreateTime { get; init; }

    /// <summary>
    /// 群创建时间
    /// </summary>
    [JsonPropertyName("group_create_time")]
    private long? GroupCreateTimeStamp
    {
        get => (GroupCreateTime ?? DateTime.MinValue).ToTimeStamp();
        init => (value ?? default).ToDateTime();
    }

    /// <summary>
    /// 群等级
    /// </summary>
    [JsonPropertyName("group_level")]
    public int? GroupLevel { get; init; }

    #endregion
}