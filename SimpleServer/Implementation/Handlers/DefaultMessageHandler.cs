using SimpleServerCommon;
using System;

namespace SimpleServer
{
    public class DefaultMessageHandler : IMessageHandler
    {
        public byte Code
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int? SubCode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MessageType Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HandlerMessage(IMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
