
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleServer
{

    public abstract class ClientHandler : IHandler<IClientPeer>
    {
        public abstract MessageType Type { get; }
        public abstract byte Code { get; }
      
        public bool HandlerMessage(IMessage message, IClientPeer peer)
        {
            OnHandlerMessage(message, peer);
            return true;
        }

        public abstract bool OnHandlerMessage(IMessage message, IClientPeer peer);


    }

}