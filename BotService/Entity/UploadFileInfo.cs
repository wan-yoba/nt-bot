using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 上传文件的信息
/// </summary>
public readonly struct UploadFileInfo
{
    /// <summary>
    /// 文件 ID
    /// </summary>
    [JsonPropertyName("id")]
    public string FileId { get; init; }

    /// <summary>
    /// 文件名
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// 文件大小(Byte)
    /// </summary>
    [JsonPropertyName("size")]
    public long Size { get; init; }

    /// <summary>
    /// 未知字段
    /// </summary>
    [JsonPropertyName("busid")]
    public long Busid { get; init; }
}