using System;

namespace SimpleServer
{
    public class DefaultRequestHandler : ClientHandler
    {
        public override byte Code
        {
            get { return RequestCode.DEFAULT; }
        }

        public override MessageType Type
        {
            get { return MessageType.Request; }
        }

        public override bool OnHandlerMessage(IMessage message, IClientPeer peer)
        {
            return true;
        }
    }
}
