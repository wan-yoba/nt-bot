using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// <para>群组请求信息</para>
/// <para>通过获取群系统消息API获得</para>
/// </summary>
public readonly struct GroupRequestInfo
{
    /// <summary>
    /// 请求ID
    /// </summary>
    [JsonPropertyName("request_id")]
    public long Id { get; init; }

    /// <summary>
    /// 请求源UID
    /// </summary>
    [JsonPropertyName("invitor_uin")]
    public long UserId { get; init; }

    /// <summary>
    /// 请求源用户名
    /// </summary>
    [JsonPropertyName("invitor_nick")]
    public string UserNick { get; init; }

    /// <summary>
    /// <para>验证消息</para>
    /// <para>当信息类型为邀请列表时此字段为空</para>
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; init; }

    /// <summary>
    /// 请求源群号
    /// </summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; init; }

    /// <summary>
    /// 请求源群名
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; init; }

    /// <summary>
    /// 请求是否已经被处理
    /// </summary>
    [JsonPropertyName("checked")]
    public bool Checked { get; init; }

    /// <summary>
    /// <para>处理者UID</para>
    /// <para>未处理时为0</para>
    /// </summary>
    [JsonPropertyName("actor")]
    public long ActorUserId { get; init; }
}