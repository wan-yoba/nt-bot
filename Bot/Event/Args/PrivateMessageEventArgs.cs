using BotService.Message.MessageEvent;

namespace Bot.Event.Args;

public class PrivateMessageEventArgs(OnebotPrivateMsgEventArgs privateMessage) : BotEventArgs
{
    private OnebotPrivateMsgEventArgs _privateMessage { get; } = privateMessage;

    public override object Data => _privateMessage;
}