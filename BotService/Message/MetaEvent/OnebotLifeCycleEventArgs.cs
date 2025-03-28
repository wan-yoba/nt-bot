using System.Text.Json.Serialization;

namespace BotService.Message.MetaEvent;

/// <summary>
/// 生命周期事件
/// </summary>
public sealed class OnebotLifeCycleEventArgs : BaseObMetaEventArgs
{
    /// <summary>
    /// <para>事件子类型</para>
    /// <para>当前版本只可能为<see langword="connect"/></para>
    /// </summary>
    [JsonPropertyName("sub_type")]
    public string SubType { get; set; }
}