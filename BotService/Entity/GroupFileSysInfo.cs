using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 群文件系统信息
/// </summary>
public readonly struct GroupFileSysInfo
{
    /// <summary>
    /// 文件总数
    /// </summary>
    [JsonPropertyName("file_count")]
    public int FileCount { get; init; }

    /// <summary>
    /// 文件数量上限
    /// </summary>
    [JsonPropertyName("limit_count")]
    public int FileLimit { get; init; }

    /// <summary>
    /// 已使用空间(Byte)
    /// </summary>
    [JsonPropertyName("used_space")]
    public long UsedSpace { get; init; }

    /// <summary>
    /// 总空间(Byte)
    /// </summary>
    [JsonPropertyName("total_space")]
    public long TotalSpace { get; init; }
}