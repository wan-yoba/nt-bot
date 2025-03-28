using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration;

namespace BotService.Entity;

/// <summary>
/// 用户信息
/// </summary>
public struct UserInfo
{
    #region 属性

    /// <summary>
    /// 用户id
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    /// <summary>
    /// 权限等级
    /// </summary>
    [JsonIgnore]
    public bool IsSuperUser { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nick { get; init; }

    /// <summary>
    /// 年龄
    /// </summary>
    [JsonPropertyName("age")]
    public int Age { get; init; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonConverter(typeof(EnumSexDescriptionConverter))]
    [JsonPropertyName("sex")]
    public Sex Sex { get; init; }

    /// <summary>
    /// 等级
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; init; }

    /// <summary>
    /// 登陆天数
    /// </summary>
    [JsonPropertyName("login_days")]
    public int LoginDays { get; init; }

    /// <summary>
    /// 会员等级
    /// </summary>
    [JsonPropertyName("vip_level")]
    public string VipLevel { get; init; }

    #endregion
}