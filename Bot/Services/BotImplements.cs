using System.Text.Json;
using Bot.Constant;
using Bot.Event;
using Bot.Event.Args;
using Bot.Interfaces;
using BotService;
using BotService.Entity.Segment.DataModel;
using BotService.Enumeration;
using BotService.Enumeration.ApiType;
using BotService.Message;
using BotService.Message.MetaEvent;
using Fleck;
using Sora.OnebotModel.OnebotEvent.MessageEvent;

namespace Bot.Services;

public class BotImplements(
    ILogsServices logsServices,
    ICacheService cacheService,
    EventServices eventServices) : IBotServices
{
    private readonly CancellationTokenSource _cancellationToken = new();

    public IWebSocketConnection webSocketConnection { get; set; }

    public WebSocketServer CreateServer(string wsUrl) => new(wsUrl);

    public void StartServer(WebSocketServer server)
    {
        server.Start(socketConnection =>
        {
            socketConnection.OnOpen = () => logsServices.Info("Connected to target WebSocket server.");
            socketConnection.OnClose = () => logsServices.Info("Connection to target WebSocket server closed.");

            async void SocketConnectionOnMessage(string message)
            {
                // 消息解包并分发事件
                try
                {
                    await eventServices.DistributeEvent(message, socketConnection.ConnectionInfo.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            socketConnection.OnMessage = SocketConnectionOnMessage;

            webSocketConnection = socketConnection;
        });
    }

    public void StopServer(WebSocketServer server)
    {
        server.Dispose();
        _cancellationToken.Cancel();
    }

    public void HeartBeatChange(object? sender, HeartBeatEventArgs e)
    {
        // 事件处理逻辑，输出心跳信息
        if (e.Data is OnebotHeartBeatEventArgs heartBeat)
        {
            Console.WriteLine(
                $"心跳维护：{heartBeat.SelfId} - Time：{heartBeat.Time.ToDateTime()} - Interval：{heartBeat.Interval} - PostType：{heartBeat.PostType}");
        }
    }

    public void LifeCycleChange(object? sender, LifeCycleEventArgs e)
    {
        if (e.Data is OnebotLifeCycleEventArgs lifecycle)
        {
            Console.WriteLine(
                $"当前已登陆：{lifecycle.SelfId} - 时间：{lifecycle.Time.ToDateTime()} - 链接属性：{lifecycle.SubType}");
        }
    }

    public void PrivateMessage(object? sender, PrivateMessageEventArgs e)
    {
        Console.WriteLine($"接收到私聊消息：{JsonSerializer.Serialize(e)}");
        // 事件处理逻辑，输出心跳信息
        var msg = new OneBotRequest
        {
            ApiRequestType = ApiRequestType.SendMsg,
            ApiParams = new OneBotRequestMessageBody
            {
                UserId = 1069430666,
                Message =
                [
                    new OnebotSegment
                    {
                        MsgType = SegmentType.Text,
                        RawData = new TextSegment
                        {
                            Content = "hi world!hi"
                        }
                    },

                    new OnebotSegment
                    {
                        MsgType = SegmentType.Face,
                        RawData = new FaceSegment
                        {
                            Id = 21
                        }
                    }
                ]
            }
        };

        var jsonMsg = JsonSerializer.Serialize(msg);

        Console.WriteLine($"发送消息原始数据：{jsonMsg}");

        webSocketConnection.Send(jsonMsg);
    }

    public async void GroupMessage(object? sender, GroupMessageEventArgs e)
    {
        Console.WriteLine($"接收到群聊消息：{JsonSerializer.Serialize(e)}");

        var groupMessage = e.Data as OnebotGroupMsgEventArgs
                           ?? new OnebotGroupMsgEventArgs();

        await RunXx(groupMessage);
    }

    private async Task RunXx(OnebotGroupMsgEventArgs groupMessage)
    {
        Dictionary<long, DateTime> xxCdDic;

        if (groupMessage.RawMessage.Equals("修仙"))
        {
            await RunSign(groupMessage);

            xxCdDic = await cacheService
                          .GetCacheAsync<Dictionary<long, DateTime>>(ConstantCacheKey.XxCdKey)
                      ?? new Dictionary<long, DateTime>();

            if (xxCdDic.TryGetValue(groupMessage.SenderInfo.UserId, out var xxCdTime))
            {
                if (xxCdTime.AddMinutes(1) < DateTime.Now)
                {
                    await GroupReplyMessage(groupMessage, " 请至少一分钟之后再次尝试！");
                }
            }
            else
            {
                xxCdDic.TryAdd(groupMessage.SenderInfo.UserId, DateTime.Now);

                await cacheService.SetCacheAsync(ConstantCacheKey.XxCdKey, xxCdDic, TimeSpan.FromDays(1));

                await GroupReplyMessage(groupMessage, " /修炼", true);

                await GroupReplyMessage(groupMessage, " 赛博修仙[启动].");
            }
        }

        if (groupMessage.MessageList.Any(a => a.MsgType == SegmentType.At))
        {
            xxCdDic = await cacheService
                          .GetCacheAsync<Dictionary<long, DateTime>>(ConstantCacheKey.XxCdKey)
                      ?? new Dictionary<long, DateTime>();

            var atMsg = groupMessage.MessageList
                .FirstOrDefault(f => f.MsgType == SegmentType.At);

            var at = JsonSerializer.Deserialize<AtSegment>(atMsg.RawDataJson);
            if (at?.Target == groupMessage.SelfId.ToString()
                && groupMessage.RawMessage.Contains("本次修炼增加"))
            {
                for (var i = 0; i < 3; i++)
                {
                    await GroupReplyMessage(groupMessage, " 破", true);

                    await Task.Delay(1000);
                }

                // 继续修仙
                xxCdDic.TryAdd(groupMessage.SenderInfo.UserId, DateTime.Now);

                await cacheService.SetCacheAsync(ConstantCacheKey.XxCdKey, xxCdDic, TimeSpan.FromDays(1));

                await GroupReplyMessage(groupMessage, " /修炼", true);
            }
        }
    }

    private async Task RunSign(OnebotGroupMsgEventArgs groupMessage)
    {
        var signDic = await cacheService
                          .GetCacheAsync<Dictionary<long, DateTime>>(ConstantCacheKey.XxSign)
                      ?? new Dictionary<long, DateTime>();

        if (signDic.TryGetValue(groupMessage.SenderInfo.UserId, out var signTime))
        {
            if (signTime.Date != DateTime.Now.Date)
            {
                await GroupReplyMessage(groupMessage, " 修仙签到", true);
            }
            else
            {
                return;
            }
        }

        await GroupReplyMessage(groupMessage, " 修仙签到", true);
        signDic.TryAdd(groupMessage.SenderInfo.UserId, DateTime.Now);
        await cacheService.SetCacheAsync(ConstantCacheKey.XxSign, signDic, TimeSpan.FromDays(30));
    }

    private async Task GroupReplyMessage(OnebotGroupMsgEventArgs groupMessage,
        string message,
        bool atBot = false)
    {
        var msg = new OneBotRequest
        {
            ApiRequestType = ApiRequestType.SendMsg,
            ApiParams = new OneBotRequestMessageBody
            {
                GroupId = groupMessage.GroupId,
                Message =
                [
                    new OnebotSegment
                    {
                        MsgType = SegmentType.At,
                        RawData = new AtSegment
                        {
                            Target = atBot ? "3889001741" : groupMessage.SenderInfo.UserId.ToString()
                        }
                    },
                    new OnebotSegment
                    {
                        MsgType = SegmentType.Text,
                        RawData = new TextSegment
                        {
                            Content = message
                        }
                    }
                ]
            }
        };

        var jsonMsg = JsonSerializer.Serialize(msg);

        webSocketConnection.Send(jsonMsg);
    }
}