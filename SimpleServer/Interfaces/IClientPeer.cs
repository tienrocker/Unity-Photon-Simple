using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleServer
{
    public interface IClientPeer
    {
        bool IsProxy { get; set; }
        Guid PeerId { get; set; }
        T ClientData<T>() where T : class, IClientData;
        void Disconnect();
        void SendMessage(IMessage message);
    }
}
