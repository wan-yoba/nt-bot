namespace Bot.Configs;

public class BotConfig
{
    /// <summary>
    /// 日志
    /// </summary>
    public Logging Logging { get; set; }

    /// <summary>
    /// 服务配置
    /// </summary>
    public ServerConfig ServerConfig { get; set; }
}

public class ServerConfig
{
    /// <summary>
    /// 监听地址
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    public ushort Port { get; set; }

    /// <summary>
    /// 鉴权Token
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// 路径
    /// </summary>
    public string UniversalPath { get; set; }

    /// <summary>
    /// <para>心跳包超时设置(秒)</para>
    /// <para>此值请不要小于或等于客户端心跳包的发送间隔</para>
    /// </summary>
    public uint HeartBeatTimeOut { get; set; }

    /// <summary>
    /// <para>客户端API调用超时设置(毫秒)</para>
    /// <para>默认为1000无需修改</para>
    /// </summary>
    public uint ApiTimeOut { get; set; }
}

public class Logging
{
    public LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public EnumLogLevel Default { get; set; } = EnumLogLevel.Information;
}

public enum EnumLogLevel
{
    /// <summary>
    /// 详细
    /// </summary>
    Verbose = 0,

    /// <summary>
    /// Debug
    /// </summary>
    Debug = 1,

    /// <summary>
    /// Info
    /// </summary>
    Information = 2,

    /// <summary>
    /// Warn
    /// </summary>
    Warning = 3,

    /// <summary>
    /// error
    /// </summary>
    Error = 4,

    /// <summary>
    /// Fatal
    /// </summary>
    Fatal = 5
}