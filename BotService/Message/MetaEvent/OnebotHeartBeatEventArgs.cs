using System.Text.Json.Serialization;

namespace BotService.Message.MetaEvent;

/// <summary>
/// 心跳包
/// </summary>
public sealed class OnebotHeartBeatEventArgs : BaseObMetaEventArgs
{
    /// <summary>
    /// 状态信息
    /// </summary>
   [JsonPropertyName("status")]
    public object Status { get; set; }

    /// <summary>
    /// 到下次心跳的间隔，单位毫秒
    /// </summary>
   [JsonPropertyName("interval")]
    public long Interval { get; set; }
}