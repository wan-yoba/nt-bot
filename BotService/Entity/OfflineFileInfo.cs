using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 离线文件信息
/// </summary>
public readonly struct OfflineFileInfo
{
    /// <summary>
    /// 文件名
    /// </summary>
     [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// 文件大小
    /// </summary>
     [JsonPropertyName("size")]
    public long Size { get; init; }

    /// <summary>
    /// 文件链接
    /// </summary>
     [JsonPropertyName("url")]
    public string Url { get; init; }
}