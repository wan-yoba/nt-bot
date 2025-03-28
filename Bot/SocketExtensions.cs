using Bot.Configs;
using Bot.Event;
using Bot.Event.EventImplements;
using Bot.Event.IEvents;
using Bot.Interfaces;
using Bot.ScheduledTask;
using Bot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bot;

public static class SocketExtensions
{
    public static IHostBuilder ConfigureAppSettings(this IHostBuilder builder)
    {
        return builder.ConfigureHostConfiguration(configBuilder => { configBuilder.AddJsonFile("appsettings.json"); });
    }

    public static void ConfigureCustomServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ServerConfig>(configuration.GetSection("ServerConfig"));
        //services.Configure<UserConfig>(configuration.GetSection("UserConfig"));
        services.Configure<Logging>(configuration.GetSection("Logging"));
        services.AddCustomServices();
    }

    private static void AddCustomServices(this IServiceCollection services)
    {
        // 日志操作
        services.AddScoped<ILogsServices, LogsImplements>();

        // 事件服务类
        services.AddSingleton<EventServices>();
        
        // 事件操作
        services.AddScoped<ISocketEvent, SocketEventImplements>();
        
        // 业务实现
        services.AddScoped<IBotServices, BotImplements>();

        // 缓存实现
        services.AddScoped<ICacheService, CacheImplements>();

        // 任务调度实现
        services.AddScoped<IBusinessTaskService, BusinessTaskImplements>();

        //数据库操作
        //services.AddSingleton<IUnitWork, UnitWork>();
        //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        //词云
        //services.AddSingleton<IWordcloud, WordcloudSrv>();

        //功能实现
        //services.AddScoped<IRobotInterface, RobotService>();
        //services.AddScoped<ILianInterface, LianService>();
        //services.AddScoped<IHsoInterface, HsoService>();
        //services.AddScoped<IUndercoverInterface, UndercoverService>();
        services.AddSingleton<IHostedService, WebSocketService>();
        services.AddHostedService<WebSocketService>();
        services.AddHostedService<ScheduledTaskService>();
    }
}