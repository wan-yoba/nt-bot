using Bot.Event.Args;
using BotService.Message.MessageEvent;
using BotService.Message.MetaEvent;
using Sora.OnebotModel.OnebotEvent.MessageEvent;

namespace Bot.Event.IEvents;

/// <summary>
/// 心跳维护
/// </summary>
public interface ISocketEvent
{
    /// <summary>
    /// 心跳链接
    /// </summary>
    event EventHandler<HeartBeatEventArgs> HeartBeatEvent;

    /// <summary>
    /// 生命周期
    /// </summary>
    event EventHandler<LifeCycleEventArgs> LifeCycleEvent;

    /// <summary>
    /// 私聊消息
    /// </summary>
    event EventHandler<PrivateMessageEventArgs> PrivateMessageEvent;

    event EventHandler<GroupMessageEventArgs> GroupMessageEvent;

    void HeartBeatChange(OnebotHeartBeatEventArgs param);
    void LifeCycleChange(OnebotLifeCycleEventArgs param);
    void PrivateMessage(OnebotPrivateMsgEventArgs param);
    void GroupMessage(OnebotGroupMsgEventArgs param);
}