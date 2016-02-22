using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleServer
{
    public class ClientHandlerList : IHandlerList<IClientPeer>
    {

        private readonly Dictionary<int, IHandler<IClientPeer>> _requestCodeHandlerList;

        public ClientHandlerList(IEnumerable<IHandler<IClientPeer>> handlers)
        {
            _requestCodeHandlerList = new Dictionary<int, IHandler<IClientPeer>>();

            foreach (var handler in handlers)
            {
                RegisterHandler(handler);
            }
        }

        public bool RegisterHandler(IHandler<IClientPeer> handler)
        {
            var registered = false;
            if ((handler.Type & MessageType.Request) == MessageType.Request)
            {
                if (!_requestCodeHandlerList.ContainsKey(handler.Code))
                {
                    _requestCodeHandlerList.Add(handler.Code, handler);
                    registered = true;
                }
            }
            return registered;
        }

        public bool HandlerMessage(IMessage message, IClientPeer peer)
        {
            bool handled = false;
            switch (message.Type)
            {
                case MessageType.Request:
                    if (_requestCodeHandlerList.ContainsKey(message.Code))
                    {
                        _requestCodeHandlerList[message.Code].HandlerMessage(message, peer);
                        handled = true;
                    }
                    break;
            }

            return handled;
        }
    }
}
