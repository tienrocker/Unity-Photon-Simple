using System.Collections.Generic;

namespace SimpleServer
{
    public interface IMessage
    {
        MessageType Type { get; }
        byte Code { get; }
        Dictionary<byte, object> Parameters { get; }
    }
}
