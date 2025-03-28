using System.Diagnostics;
using System.Text.Json;
using Bot.Event.IEvents;
using Bot.Interfaces;
using BotService;
using BotService.Message;
using BotService.Message.MessageEvent;
using BotService.Message.MetaEvent;
using Sora.OnebotModel.OnebotEvent.MessageEvent;

namespace Bot.Event;

public sealed class EventServices
{
    private readonly ISocketEvent _socketEvent;
    private readonly ILogsServices _logsServices;

    /// <summary>
    /// 注入
    /// </summary>
    /// <param name="socketEvent"></param>
    /// <param name="logsServices"></param>
    public EventServices(ISocketEvent socketEvent,
        ILogsServices logsServices)
    {
        _socketEvent = socketEvent;
        _logsServices = logsServices;
    }

    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="messageJson"></param>
    /// <param name="connection"></param>
    public async ValueTask DistributeEvent(string messageJson, Guid connection)
    {
        switch (TryGetJsonValue(messageJson, "post_type"))
        {
            //元事件类型
            case "meta_event":
                await MetaService(messageJson, connection);
                break;
            case "message":
                await MessageService(messageJson, connection);
                break;
            case "request":
                // await RequestAdapter(messageJson, connection);
                break;
            case "notice":
                // await NoticeAdapter(messageJson, connection);
                break;
            case "message_sent":
                // await SelfMessageAdapter(messageJson, connection);
                break;
            default:
                // 尝试从响应中获取标识符
                await OnBotResponseService(messageJson, connection);
                break;
        }
    }

    /// <summary>
    /// 元事件处理和分发
    /// </summary>
    /// <param name="messageJson">消息</param>
    /// <param name="connection">连接GUID</param>
    private async ValueTask MetaService(string messageJson, Guid connection)
    {
        switch (TryGetJsonValue(messageJson, "meta_event_type"))
        {
            //心跳包
            case "heartbeat":
            {
                if (JsonSerializer.Deserialize<OnebotHeartBeatEventArgs>(messageJson) is { } heartbeat)
                {
                    _socketEvent.HeartBeatChange(heartbeat);
                }

                break;
            }
            //生命周期
            case "lifecycle":
            {
                if (JsonSerializer.Deserialize<OnebotLifeCycleEventArgs>(messageJson.ToString()) is { } lifecycle)
                {
                    if (lifecycle.SubType != "connect")
                    {
                        // 处理链接异常
                    }

                    // 避免链接开启事件晚于生命周期事件
                    await Task.Delay(100);

                    _socketEvent.LifeCycleChange(lifecycle);
                }
                break;
            }
        }
    }

    /// <summary>
    /// 消息处理和分发
    /// </summary>
    /// <param name="messageJson"></param>
    /// <param name="connection"></param>
    private async ValueTask MessageService(string messageJson, Guid connection)
    {
        switch (TryGetJsonValue(messageJson, "message_type"))
        {
            //私聊事件
            case "private":
            {
                if (JsonSerializer.Deserialize<OnebotPrivateMsgEventArgs>(messageJson) is { } privateMsg)
                {
                    _socketEvent.PrivateMessage(privateMsg);
                }
                break;
            }
            //群聊事件
            case "group":
            {
                if (JsonSerializer.Deserialize<OnebotGroupMsgEventArgs>(messageJson) is { } groupMsg)
                {
                    _socketEvent.GroupMessage(groupMsg);
                }

                break;
            }
            default:
                // Log.Warning("Sora|Message", $"接收到未知事件[{TryGetJsonValue(messageJson, "message_type")}]");
                break;
        }
    }

    private async ValueTask OnBotResponseService(string messageJson, Guid connection)
    {
        var msgId = TryGetJsonValue(messageJson, "echo");
        if (Guid.TryParse(msgId, out Guid messageId))
        {
            if (JsonSerializer.Deserialize<OneBotResponse>(messageJson) is { } oneBotResponse)
            {
                Console.WriteLine("获取到了消息发送响应：{0}", messageJson);
                
                // 写入缓存
            }
        }
        else
        {
            _logsServices.Warn(
                $"未知类型的上报:{TryGetJsonValue(messageJson, "echo")} \r\n json = {messageJson}");
        }
    }

    /// <summary>
    /// 获取json中的值
    /// </summary>
    private string TryGetJsonValue(object dataJson, string key)
    {
        try
        {
            using var document = JsonDocument.Parse(dataJson.ToString() ?? string.Empty);
            return document.RootElement.GetProperty(key).GetString() ?? string.Empty;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"获取json值错误，key:{key}，原始数据{dataJson}");
            Debug.WriteLine(e);
        }

        return string.Empty;
    }
}