using System.Text.Json.Serialization;
using BotService.Entity;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 群文件上传事件
/// </summary>
public sealed class OnebotFileUploadEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 上传的文件信息
    /// </summary>
    [JsonPropertyName("file")]
    public UploadFileInfo Upload { get; set; }
}