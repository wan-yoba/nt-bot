using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BotService.Entity;

/// <summary>
/// 群公告
/// </summary>
public readonly struct GroupNoticeInfo
{
    /// <summary>
    /// 公告ID
    /// </summary>
    [JsonPropertyName("notice_id")]
    public string NoticeId { get; init; }

    /// <summary>
    /// 发布者
    /// </summary>
    [JsonPropertyName("sender_id")]
    public long UserId { get; init; }

    /// <summary>
    /// 发布时间
    /// </summary>
    [JsonIgnore]
    public DateTime PublishTime { get; init; }


    [JsonPropertyName("publish_time")]
    public long PublishTimeStamp
    {
        get => PublishTime.ToTimeStamp();
        init => PublishTime = value.ToDateTime();
    }

    /// <summary>
    /// 公告消息
    /// </summary>
    [JsonPropertyName("message")]
    public NoticeMessage Message { get; init; }
}

/// <summary>
/// 公告消息
/// </summary>
public readonly struct NoticeMessage
{
    /// <summary>
    /// 公告文字
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; init; }

    /// <summary>
    /// 公告图片
    /// </summary>
    [JsonPropertyName("images")]
    public List<NoticeImage> NoticeImages { get; init; }
}

/// <summary>
/// 公告图片
/// </summary>
public readonly struct NoticeImage
{
    /// <summary>
    /// 高
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; init; }

    /// <summary>
    /// 宽
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; init; }

    /// <summary>
    /// 图片ID
    /// </summary>
    [JsonPropertyName("id")]
    public string ImageId { get; init; }
}