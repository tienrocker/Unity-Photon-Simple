namespace SimpleServerCommon
{
    public interface IMessageHandler
    {
        MessageType Type { get; }
        byte Code { get; }
        int? SubCode { get; }
        bool HandlerMessage(IMessage message);
    }
}
