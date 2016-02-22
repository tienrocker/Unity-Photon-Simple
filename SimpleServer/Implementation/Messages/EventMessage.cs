using System.Collections.Generic;

namespace SimpleServer
{
    public class EventMessage : IMessage
    {
        private readonly byte _code;
        private readonly Dictionary<byte, object> _parameters;
        private readonly int? _subCode;

        public EventMessage(byte code, int? subCode, Dictionary<byte, object> parameters)
        {
            _code = code;
            _subCode = subCode;
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

        public int? SubCode
        {
            get
            {
                return _subCode;
            }
        }

        public MessageType Type
        {
            get
            {
                return MessageType.Async;
            }
        }
    }
}