using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BotService.Message;

namespace BotService.Converter;

/// <summary>
/// 消息预处理扩展函数
/// </summary>
public class OneBotMessageConverter : JsonConverter<List<OnebotSegment>>
{
    #region 上报消息处理

    //
    // /// <summary>
    // /// 处理接收到的消息段
    // /// </summary>
    // /// <param name="onebotSegment">消息段</param>
    // /// <returns>消息段列表</returns>
    // private static SoraSegment ParseMessageElement(OnebotSegment onebotSegment)
    // {
    //     if (onebotSegment.RawData == null)
    //         return new SoraSegment(SegmentType.Unknown, null);
    //     try
    //     {
    //         JObject jsonObj = JObject.FromObject(onebotSegment.RawData);
    //         if (jsonObj.Count == 0)
    //             return new SoraSegment(SegmentType.Unknown, null);
    //         return onebotSegment.MsgType switch
    //                {
    //                    SegmentType.Text => new SoraSegment(SegmentType.Text, jsonObj.ToObject<TextSegment>()),
    //                    SegmentType.Face => new SoraSegment(SegmentType.Face, jsonObj.ToObject<FaceSegment>()),
    //                    SegmentType.Image => new SoraSegment(SegmentType.Image, jsonObj.ToObject<ImageSegment>()),
    //                    SegmentType.Record => new SoraSegment(SegmentType.Record, jsonObj.ToObject<RecordSegment>()),
    //                    SegmentType.At => new SoraSegment(SegmentType.At, jsonObj.ToObject<AtSegment>()),
    //                    SegmentType.Share => new SoraSegment(SegmentType.Share, jsonObj.ToObject<ShareSegment>()),
    //                    SegmentType.Reply => new SoraSegment(SegmentType.Reply, jsonObj.ToObject<ReplySegment>()),
    //                    SegmentType.Forward => new SoraSegment(SegmentType.Forward, jsonObj.ToObject<ForwardSegment>()),
    //                    SegmentType.Xml => new SoraSegment(SegmentType.Xml, jsonObj.ToObject<CodeSegment>()),
    //                    SegmentType.Json => new SoraSegment(SegmentType.Json, jsonObj.ToObject<CodeSegment>()),
    //                    _ => new SoraSegment(SegmentType.Unknown, new UnknownSegment { Content = jsonObj })
    //                };
    //     }
    //     catch (Exception e)
    //     {
    //         Log.Error("Sora", Log.ErrorLogBuilder(e));
    //         Log.Error("Sora", $"JsonSegment转换错误 未知格式，出错类型[{onebotSegment.MsgType}],请向框架开发者反应此问题");
    //         return new SoraSegment(SegmentType.Unknown, null);
    //     }
    // }
    //
    // /// <summary>
    // /// 处理消息段数组
    // /// </summary>
    // /// <param name="messages">消息段数组</param>
    // [Reviewed("nidbCN", "2021-03-24 19:49")]
    // public static MessageBody ToMessageBody(this List<OnebotSegment> messages)
    // {
    //     Log.Debug("Sora", "Parsing msg list");
    //     if (messages == null || messages.Count == 0)
    //         return new MessageBody();
    //     List<SoraSegment> retMsg = messages.Select(ParseMessageElement).ToList();
    //
    //     Log.Debug("Sora", $"Get msg len={retMsg.Count}");
    //     return new MessageBody(retMsg);
    // }

    #endregion

    public override List<OnebotSegment> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        var segments = new List<OnebotSegment>();

        if (reader.TokenType is JsonTokenType.StartArray)
        {
            while (reader.Read() && reader.TokenType is not JsonTokenType.EndArray)
            {
            }
        }
        
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, List<OnebotSegment> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}