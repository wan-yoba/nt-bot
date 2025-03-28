using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 好友信息
/// </summary>
public sealed record FriendInfo
{
    #region 属性

    /// <summary>
    /// 好友备注
    /// </summary>
    [JsonPropertyName("remark")]
    public string Remark { get; init; }

    /// <summary>
    /// 用户名
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nick { get; init; }

    /// <summary>
    /// 是否为机器人管理员
    /// </summary>
    [JsonIgnore]
    public bool IsSuperUser { get; set; }

    /// <summary>
    /// 好友ID
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    #endregion
}