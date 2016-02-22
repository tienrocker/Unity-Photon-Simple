namespace SimpleServer
{
    public interface IHandler<T>
    {
        MessageType Type { get; }
        byte Code { get; }
        bool HandlerMessage(IMessage message, T peer);
    }
}