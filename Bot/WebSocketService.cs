using Bot.Configs;
using Bot.Event.IEvents;
using Bot.Interfaces;
using Fleck;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Bot;

public class WebSocketService(
    ISocketEvent socketEvent,
    ILogsServices logsServices,
    IBotServices botServices,
    IOptions<ServerConfig> serverConfig,
    IOptions<Logging> logging
) : IHostedService, IDisposable
{
    private bool _disposedValue;
    private WebSocketServer webSocketServer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // 日志启动
        LogStartup();
        
        // 配置检查
        var wsUrl = CheckServerConfig();

        webSocketServer = botServices.CreateServer(wsUrl);

        botServices.StartServer(webSocketServer);
        
        // 订阅事件
        RegisterEventHandlers();

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        botServices.StopServer(webSocketServer);
        return Task.CompletedTask;
    }

    private void LogStartup()
    {
        logsServices.Info("Service Starting!");

        var level = logging.Value.LogLevel.Default;

        logsServices.SetLogLevel(level);
    }

    private string CheckServerConfig()
    {
        if (string.IsNullOrEmpty(serverConfig.Value.Location) ||
            string.IsNullOrEmpty(serverConfig.Value.AccessToken) ||
            string.IsNullOrEmpty(serverConfig.Value.Port.ToString()) ||
            string.IsNullOrEmpty(serverConfig.Value.UniversalPath))
            logsServices.Fatal("服务配置有误!");

        return $"ws://{serverConfig.Value.Location}:{serverConfig.Value.Port}{serverConfig.Value.UniversalPath}";
    }

    private void RegisterEventHandlers()
    {
        socketEvent.HeartBeatEvent += botServices.HeartBeatChange;
        socketEvent.LifeCycleEvent += botServices.LifeCycleChange;
        socketEvent.PrivateMessageEvent += botServices.PrivateMessage;
        socketEvent.GroupMessageEvent += botServices.GroupMessage;
    }

    private void Dispose(bool disposing)
    {
        if (_disposedValue) return;
        
        if (disposing)
        {
            botServices.StopServer(webSocketServer);
            // 释放托管状态 (托管对象)
        }

        // 释放未托管的资源 (未托管的对象) 并重写终结器
        _disposedValue = true;
    }

    ~WebSocketService()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}