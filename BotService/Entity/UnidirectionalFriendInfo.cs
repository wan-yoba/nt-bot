using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 单向好友信息
/// </summary>
public readonly struct UnidirectionalFriendInfo
{
    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public string NickName { get; init; }

    /// <summary>
    /// 用户QQ号
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    /// <summary>
    /// 添加途径
    /// </summary>
    [JsonPropertyName("source")]
    public string Source { get; init; }
}