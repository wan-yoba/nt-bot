using Bot.Event.Args;
using Bot.Event.IEvents;
using BotService.Message.MessageEvent;
using BotService.Message.MetaEvent;
using Sora.OnebotModel.OnebotEvent.MessageEvent;

namespace Bot.Event.EventImplements;

public sealed class SocketEventImplements : ISocketEvent
{
    public event EventHandler<HeartBeatEventArgs>? HeartBeatEvent;
    public event EventHandler<LifeCycleEventArgs>? LifeCycleEvent;
    public event EventHandler<PrivateMessageEventArgs>? PrivateMessageEvent;
    public event EventHandler<GroupMessageEventArgs>? GroupMessageEvent;

    public void HeartBeatChange(OnebotHeartBeatEventArgs param)
        => OnHeartBeatChanged(new HeartBeatEventArgs(param));

    public void LifeCycleChange(OnebotLifeCycleEventArgs param)
        => OnHeartBeatChanged(new LifeCycleEventArgs(param));

    public void PrivateMessage(OnebotPrivateMsgEventArgs param)
        => OnPrivateMessage(new PrivateMessageEventArgs(param));

    public void GroupMessage(OnebotGroupMsgEventArgs param)
        => OnGroupMessage(new GroupMessageEventArgs(param));

    private void OnHeartBeatChanged(HeartBeatEventArgs eventArgs) =>
        HeartBeatEvent?.Invoke(this, eventArgs);

    private void OnHeartBeatChanged(LifeCycleEventArgs eventArgs) =>
        LifeCycleEvent?.Invoke(this, eventArgs);

    private void OnPrivateMessage(PrivateMessageEventArgs eventArgs) =>
        PrivateMessageEvent?.Invoke(this, eventArgs);

    private void OnGroupMessage(GroupMessageEventArgs eventArgs) =>
        GroupMessageEvent?.Invoke(this, eventArgs);
}