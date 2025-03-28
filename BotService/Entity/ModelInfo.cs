using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 型号信息
/// </summary>
public struct ModelInfo
{
    /// <summary>
    /// 型号
    /// </summary>
    [JsonPropertyName("model_show")]
    public string ModelString { get; set; }

    /// <summary>
    /// 需要会员
    /// </summary>
    [JsonPropertyName("need_pay")]
    public bool NeedVip { get; set; }
}