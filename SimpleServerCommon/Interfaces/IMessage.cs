using System;
using System.Collections.Generic;

namespace SimpleServerCommon
{
    public interface IMessage
    {
        MessageType Type { get; }
        byte Code { get; }
        int? SubCode { get; }
        Dictionary<byte, object> Parameters { get; }
    }

    [Flags]
    public enum MessageType
    {
        Request = 0x1,
        Response = 0x2,
        Async = 0x4
    }
}
