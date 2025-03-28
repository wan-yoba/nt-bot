using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BotService.Message;

/// <summary>
/// 消息体请求
/// </summary>
public class OneBotRequestMessageBody
{
    /// <summary>
    /// 用户
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 群组
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 消息段
    /// </summary>
    [JsonPropertyName("message")]
    public List<OnebotSegment> Message { get; set; }
}