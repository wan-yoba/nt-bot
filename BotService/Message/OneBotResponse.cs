using System.Text.Json.Serialization;

namespace BotService.Message;

/// <summary>
/// onebot发送消息响应
/// </summary>
public class OneBotResponse
{
    [JsonPropertyName("status")] public string Status { get; set; }

    [JsonPropertyName("retcode")] public int RetCode { get; set; }

    [JsonPropertyName("data")] public OneBotResponseData? Data { get; set; }

    [JsonPropertyName("echo")] public object? Echo { get; set; }

    /// <summary>
    /// 是否成功
    /// </summary>
    public bool IsSuccess => Status == "ok" && RetCode == 0;
}

/// <summary>
/// onebot发送消息响应 消息ID
/// </summary>
public class OneBotResponseData
{
    [JsonPropertyName("message_id")] public int MessageId { get; set; }
}