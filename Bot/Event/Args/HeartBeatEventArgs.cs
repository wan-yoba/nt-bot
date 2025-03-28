using BotService.Message.MetaEvent;

namespace Bot.Event.Args;

public class HeartBeatEventArgs(OnebotHeartBeatEventArgs heartBeat) : BotEventArgs
{
    private OnebotHeartBeatEventArgs _heartBeat { get; } = heartBeat;

    public override object Data => _heartBeat;
}