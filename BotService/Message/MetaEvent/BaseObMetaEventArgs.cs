using System.Text.Json.Serialization;
using BotService.Entity;

namespace BotService.Message.MetaEvent;

/// <summary>
/// 元事件基类
/// </summary>
public abstract class BaseObMetaEventArgs : BaseObApiEventArgs
{
    /// <summary>
    /// 元事件类型
    /// </summary>
   [JsonPropertyName("meta_event_type")]
    public string MetaEventType { get; set; }
}