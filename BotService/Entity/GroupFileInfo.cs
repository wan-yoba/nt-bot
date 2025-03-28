using System;
using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 群文件信息
/// </summary>
public readonly struct GroupFileInfo
{
    /// <summary>
    /// 文件ID
    /// </summary>
    [JsonPropertyName("file_id")]
    public string Id { get; init; }

    /// <summary>
    /// 文件名
    /// </summary>
    [JsonPropertyName("file_name")]
    public string Name { get; init; }

    /// <summary>
    /// 文件类型ID
    /// </summary>
    [JsonPropertyName("busid")]
    public int BusId { get; init; }

    /// <summary>
    /// 文件大小
    /// </summary>
    [JsonPropertyName("file_size")]
    public long Size { get; init; }

    /// <summary>
    /// 上传时间
    /// </summary>
    [JsonIgnore]
    public DateTime UploadTime => UploadTimeStamp.ToDateTime();

    [JsonPropertyName("upload_time")] private long UploadTimeStamp { get; init; }

    /// <summary>
    /// <para>过期时间</para>
    /// <para>永久文件为0</para>
    /// </summary>
    [JsonIgnore]
    public DateTime DeadTime => DeadTimeStamp.ToDateTime();

    [JsonPropertyName("dead_time")] private long DeadTimeStamp { get; init; }

    /// <summary>
    /// 修改时间
    /// </summary>
    [JsonIgnore]
    public DateTime ModifyTime => ModifyTimeStamp.ToDateTime();

    [JsonPropertyName("modify_time")] private long ModifyTimeStamp { get; init; }

    /// <summary>
    /// 下载次数
    /// </summary>
    [JsonPropertyName("download_times")]
    public int DownloadCount { get; init; }

    /// <summary>
    /// 上传者UID
    /// </summary>
    [JsonPropertyName("uploader")]
    public long UploadUserId { get; init; }

    /// <summary>
    /// 上传者名
    /// </summary>
    [JsonPropertyName("uploader_name")]
    public string UploadUserName { get; init; }
}