using System.Text.Json.Serialization;

namespace BotService.Message.NoticeEvent;

/// <summary>
/// 戳一戳或运气王事件
/// </summary>
public sealed class OnebotPokeOrLuckyEventArgs : BaseObNotifyEventArgs
{
    /// <summary>
    /// 目标UID
    /// </summary>
    [JsonPropertyName("target_id")]
    public long TargetId { get; set; }
}