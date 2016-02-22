namespace SimpleServer
{
    public interface IHandlerList<T>
    {
        bool RegisterHandler(IHandler<T> handler);
        bool HandlerMessage(IMessage message, T peer);
    }
}