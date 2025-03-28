using System.Text.Json.Serialization;
using BotService.Entity;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 离线文件事件
/// </summary>
public sealed class OnebotOfflineFileEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 离线文件信息
    /// </summary>
    [JsonPropertyName("file")]
    public OfflineFileInfo Info { get; set; }
}