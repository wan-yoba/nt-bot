using BotService.Message.MetaEvent;

namespace Bot.Event.Args;

public class LifeCycleEventArgs(OnebotLifeCycleEventArgs lifecycle) : BotEventArgs
{
    private OnebotLifeCycleEventArgs _lifecycle { get; } = lifecycle;

    public override object Data => _lifecycle;
}