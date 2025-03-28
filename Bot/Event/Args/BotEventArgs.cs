namespace Bot.Event.Args;

public abstract class BotEventArgs : EventArgs
{
    // 事件的数据，子类可以重写这个属性
    public abstract object Data { get; }
}