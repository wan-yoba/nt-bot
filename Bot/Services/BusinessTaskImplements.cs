using Bot.Constant;
using Bot.Interfaces;
using Fleck;

namespace Bot.Services;

public class BusinessTaskImplements(ICacheService cacheService) : IBusinessTaskService
{
    public async Task XslExecuteAsync(IWebSocketConnection socket, CancellationToken cancellationToken)
    {
        Dictionary<long, long> xslDic;
        xslDic = await cacheService
                     .GetCacheAsync<Dictionary<long, long>>(ConstantCacheKey.Xsl)
                 ?? new Dictionary<long, long>();
        
        
        
        throw new NotImplementedException();
    }

    public Task ZmTaskExecuteAsync(IWebSocketConnection socket, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task LdExecuteAsync(IWebSocketConnection socket, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task Xsl()
    {
        
    }
}