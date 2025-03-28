using Sora.OnebotModel.OnebotEvent.MessageEvent;

namespace Bot.Event.Args;

public class GroupMessageEventArgs(OnebotGroupMsgEventArgs groupMsg) : BotEventArgs
{
    private OnebotGroupMsgEventArgs _groupMsg { get; } = groupMsg;

    public override object Data => _groupMsg;
}