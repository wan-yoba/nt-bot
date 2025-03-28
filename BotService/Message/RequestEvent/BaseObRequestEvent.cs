using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Entity;
using BotService.Enumeration.EventParamsType;

namespace BotService.Message.RequestEvent;

/// <summary>
/// 请求事件基类
/// </summary>
public abstract class BaseObRequestEvent : BaseObApiEventArgs
{
    /// <summary>
    /// 请求类型
    /// </summary>
    [JsonPropertyName("request_type")]
    [JsonConverter(typeof(EnumRequestDescriptionConverter))]
    public RequestType RequestType { get; set; }

    /// <summary>
    /// 发送请求的 QQ 号
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 验证信息
    /// </summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// 请求 flag
    /// </summary>
    [JsonPropertyName("flag")]
    public string Flag { get; set; }
}