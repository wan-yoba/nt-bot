using System;
using System.Text.Json.Serialization;
using BotService.Converter;
using BotService.Enumeration.ApiType;

namespace BotService.Message;

public sealed class OneBotRequest
{
    /// <summary>
    /// API请求类型
    /// </summary>
    [JsonPropertyName("action")]
    [JsonConverter(typeof(EnumOnebotRequestDescriptionConverter))]
    public ApiRequestType ApiRequestType { get; init; }

    /// <summary>
    /// 请求标识符
    /// 会自动生成初始值不需要设置
    /// </summary>
    [JsonPropertyName("echo")]
    public Guid Echo { get; } = Guid.NewGuid();

    /// <summary>
    /// API参数对象
    /// 不需要参数时不需要设置
    /// </summary>
    [JsonPropertyName("params")]
    public object ApiParams { get; init; } = new { };
}