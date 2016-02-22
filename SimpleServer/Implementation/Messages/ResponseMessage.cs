using System.Collections.Generic;

namespace SimpleServer
{
    public class ResponseMessage : IMessage
    {
        private readonly byte _code;
        private readonly Dictionary<byte, object> _parameters;

        // Photon specific at the moment
        private readonly string _debugMessage;
        private readonly short _returnCode;

        public ResponseMessage(byte code, Dictionary<byte, object> parameters)
        {
            _code = code;
            _parameters = parameters;
        }

        public ResponseMessage(byte code, Dictionary<byte, object> parameters, string debugMessage, short returnCode)
            : this(code, parameters)
        {
            _debugMessage = debugMessage;
            _returnCode = returnCode;
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
                return MessageType.Response;
            }
        }

        public string DebugMessage
        {
            get
            {
                return _debugMessage;
            }
        }

        public short ReturnCode
        {
            get
            {
                return _returnCode;
            }
        }
    }
}