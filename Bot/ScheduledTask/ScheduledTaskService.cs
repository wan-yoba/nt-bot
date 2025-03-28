using Bot.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Bot.ScheduledTask;

public class ScheduledTaskService(
    IBusinessTaskService businessTaskService,
    IBotServices botServices) : IHostedService, IDisposable
{
    private Timer? _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // 设置定时器，每分钟执行一次任务
        _timer = new Timer(ExecuteTask,
            null,
            TimeSpan.Zero,
            TimeSpan.FromMinutes(10));
        return Task.CompletedTask;
    }

    private async void ExecuteTask(object? state)
    {
        // 执行特定的业务逻辑
        await businessTaskService.LdExecuteAsync(botServices.webSocketConnection, CancellationToken.None);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // 停止定时器
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        // 清理资源
        _timer?.Dispose();
    }
}