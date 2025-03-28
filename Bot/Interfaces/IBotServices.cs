using Bot.Event.Args;
using Fleck;

namespace Bot.Interfaces;

public interface IBotServices
{
    /// <summary>
    /// webSocketConnection
    /// </summary>
    public IWebSocketConnection webSocketConnection { get; set; }

    /// <summary>
    /// WebSocketServer
    /// </summary>
    WebSocketServer CreateServer(string wsUrl);

    /// <summary>
    /// 启动socket
    /// </summary>
    /// <param name="server"></param>
    void StartServer(WebSocketServer server);

    /// <summary>
    /// 停止socket
    /// </summary>
    /// <param name="server"></param>
    void StopServer(WebSocketServer server);

    /// <summary>
    /// 处理心跳链接
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void HeartBeatChange(object? sender, HeartBeatEventArgs e);

    /// <summary>
    /// 生命周期
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void LifeCycleChange(object? sender, LifeCycleEventArgs e);

    /// <summary>
    /// 私聊消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void PrivateMessage(object? sender, PrivateMessageEventArgs e);

    /// <summary>
    /// 群聊消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void GroupMessage(object? sender, GroupMessageEventArgs e);
}