using System.ComponentModel;

namespace BotService.Enumeration;

/// <summary>
/// 消息段类型
/// </summary>
[DefaultValue(Unknown)]
public enum SegmentType
{
    /// <summary>
    /// 未知
    /// </summary>
    Unknown,

    /// <summary>
    /// 忽略
    /// </summary>
    Ignore,

#region 基础消息段

    /// <summary>
    /// 纯文本
    /// </summary>
    [Description("text")]
    Text,

    /// <summary>
    /// QQ 表情
    /// </summary>
    [Description("face")]
    Face,

    /// <summary>
    /// 图片
    /// </summary>
    [Description("image")]
    Image,

    /// <summary>
    /// 语音
    /// </summary>
    [Description("record")]
    Record,

    /// <summary>
    /// 短视频
    /// </summary>
    [Description("video")]
    Video,

    /// <summary>	
    /// <para>音乐分享</para>	
    /// <para>只能发送</para>	
    /// </summary>	
    [Description("music")]
    Music,

    /// <summary>
    /// @某人
    /// </summary>
    [Description("at")]
    At,

    /// <summary>
    /// 链接分享
    /// </summary>
    [Description("share")]
    Share,

    /// <summary>
    /// 回复
    /// </summary>
    [Description("reply")]
    Reply,

    /// <summary>
    /// <para>合并转发</para>
    /// <para>只能接收</para>
    /// </summary>
    [Description("forward")]
    Forward,

#endregion

#region GoCQ扩展消息段

    /// <summary>
    /// 群戳一戳
    /// </summary>
    [Description("poke")]
    Poke,

    /// <summary>
    /// XML 消息
    /// </summary>
    [Description("xml")]
    Xml,

    /// <summary>
    /// JSON 消息
    /// </summary>
    [Description("json")]
    Json,

    /// <summary>
    /// 接收红包
    /// </summary>
    [Description("redbag")]
    RedBag,

    /// <summary>
    /// 装逼大图
    /// </summary>
    [Description("cardimage")]
    CardImage,

    /// <summary>
    /// 文本转语音
    /// </summary>
    [Description("tts")]
    TTS,

    /// <summary>
    /// 猜拳
    /// </summary>
    [Description("rps")]
    RPS

#endregion
}