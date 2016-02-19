using SimpleServerCommon;
using System;
using System.Collections.Generic;

namespace SimpleServer
{
    public class DefaultMessage : IMessage
    {
        public byte Code
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Dictionary<byte, object> Parameters
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
    }
}
