using Fleck;
using Sora.OnebotModel.OnebotEvent.MessageEvent;

namespace Bot.Interfaces;

public interface IBusinessTaskService
{
    // 悬赏令
    Task XslExecuteAsync(IWebSocketConnection socket, CancellationToken cancellationToken);
    
    // 宗门任务
    Task ZmTaskExecuteAsync(IWebSocketConnection socket, CancellationToken cancellationToken);
    
    // 炼丹
    Task LdExecuteAsync(IWebSocketConnection socket, CancellationToken cancellationToken);
}