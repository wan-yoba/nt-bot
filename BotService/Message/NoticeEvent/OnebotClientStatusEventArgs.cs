using System.Text.Json.Serialization;
using BotService.Entity;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 其他客户端在线状态变更
/// </summary>
public sealed class OnebotClientStatusEventArgs : BaseObNoticeEventArgs
{
    /// <summary>
    /// 客户端信息
    /// </summary>
    [JsonPropertyName("client")]
    public ClientInfo ClientInfo { get; set; }

    /// <summary>
    /// 是否在线
    /// </summary>
    [JsonPropertyName("online")]
    public bool Online { get; set; }
}