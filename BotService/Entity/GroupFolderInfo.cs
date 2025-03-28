using System;
using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 群文件夹信息
/// </summary>
public readonly struct GroupFolderInfo
{
    /// <summary>
    /// 文件夹ID
    /// </summary>
    [JsonPropertyName("folder_id")]
    public string Id { get; init; }

    /// <summary>
    /// 文件夹名
    /// </summary>
    [JsonPropertyName("folder_name")]
    public string Name { get; init; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonIgnore]
    public DateTime CreateTime => CreateTimeStamp.ToDateTime();

    [JsonPropertyName("create_time")] private long CreateTimeStamp { get; init; }

    /// <summary>
    /// 创建者UID
    /// </summary>
    [JsonPropertyName("creator")]
    public long CreatorUserId { get; init; }

    /// <summary>
    /// 创建者名
    /// </summary>
    [JsonPropertyName("creator_name")]
    public string CreatorUserName { get; init; }

    /// <summary>
    /// 子文件数量
    /// </summary>
    [JsonPropertyName("total_file_count")]
    public int FileCount { get; init; }
}