using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleServer
{

    public class RequestMessage : IMessage
    {
        private readonly byte _code;
        private readonly Dictionary<byte, object> _parameters;

        public RequestMessage(byte code, Dictionary<byte, object> parameters)
        {
            _code = code;
            _parameters = parameters;
        }

        public byte Code
        {
            get
            {
                return _code;
            }
        }

        public Dictionary<byte, object> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public MessageType Type
        {
            get
            {
                return MessageType.Request;
            }
        }
    }
}
