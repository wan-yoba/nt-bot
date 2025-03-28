using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// OneBot事件基类
/// </summary>
public abstract class BaseObApiEventArgs
{
    /// <summary>
    /// 事件发生的时间戳
    /// </summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }

    /// <summary>
    /// 收到事件的机器人 QQ 号
    /// </summary>
    [JsonPropertyName("self_id")]
    public long SelfId { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    [JsonPropertyName("post_type")]
    public string PostType { get; set; }
}