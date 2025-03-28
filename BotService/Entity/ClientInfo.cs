using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 设备信息
/// </summary>
public readonly struct ClientInfo
{
    /// <summary>
    /// 客户端ID
    /// </summary>
    [JsonPropertyName("app_id")]
    public long AppId { get; init; }

    /// <summary>
    /// 设备名
    /// </summary>
    [JsonPropertyName("device_name")]
    public string DeviceName { get; init; }

    /// <summary>
    /// 设备类型
    /// </summary>
    [JsonPropertyName("device_kind")]
    public string Device { get; init; }
}