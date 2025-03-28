using System;
using System.Text.Json.Serialization;
using ProtoBuf;

namespace BotService.Entity.Segment.DataModel;

/// <summary>
/// 图片
/// </summary>
[ProtoContract]
public sealed record ImageSegment : BaseSegment
{
    /// <summary>
    /// 文件名/绝对路径/URL/base64
    /// </summary>
    [JsonPropertyName("file")]
    [ProtoMember(1)]
    public string ImgFile { get; init; }

    /// <summary>
    /// 图片类型
    /// </summary>
    [JsonPropertyName("type")]
    [ProtoMember(2)]
    public string ImgType { get; init; }

    /// <summary>
    /// 图片链接
    /// </summary>
    [JsonPropertyName("url")]
    [ProtoMember(3)]
    public string Url { get; set; }

    /// <summary>
    /// 只在通过网络 URL 发送时有效，表示是否使用已缓存的文件
    /// </summary>
    [JsonPropertyName("cache")]
    [ProtoMember(4)]
    public int? UseCache { get; set; }

    /// <summary>
    /// 通过网络下载图片时的线程数，默认单线程。
    /// </summary>
    [JsonPropertyName("c")]
    [ProtoMember(5)]
    public int? ThreadCount { get; set; }

    /// <summary>
    /// 发送秀图时的特效id，默认为40000
    /// </summary>
    [JsonPropertyName("id")]
    [ProtoMember(6)]
    public int? Id { get; set; }

    /// <summary>
    /// <para>图片子类型</para>
    /// <para>此类型暂只做反序列化处理，不做枚举类型处理</para>
    /// <para>参照：https://github.com/Mrs4s/go-cqhttp/blob/master/docs/cqhttp.md#%E5%9B%BE%E7%89%87</para>
    /// </summary>
    [JsonPropertyName("subType")]
    [ProtoMember(7)]
    public int? SubType { get; set; }

    /// <summary>
    /// Equals
    /// </summary>
    /// <param name="other">图片</param>
    public bool Equals(ImageSegment other)
    {
        return ImgFile == other.ImgFile && ImgType == other.ImgType;
    }

    /// <summary>
    /// GetHashCode
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), ImgFile, ImgType);
    }
}