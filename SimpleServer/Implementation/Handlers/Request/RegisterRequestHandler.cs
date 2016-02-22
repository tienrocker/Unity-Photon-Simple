using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace SimpleServer
{
    public class RegisterRequestHandler : ClientHandler
    {
        public override byte Code
        {
            get
            {
                return RequestCode.GLOBAL_ACTION_REQUEST;
            }
        }

        public override MessageType Type
        {
            get
            {
                return MessageType.Request;
            }
        }

        public override bool OnHandlerMessage(IMessage message, IClientPeer peer)
        {
            string username = message.Parameters[LoginRequestData.LOGIN_DATA_USERNAME].ToString();
            string password = message.Parameters[LoginRequestData.LOGIN_DATA_PASSWORD].ToString();

            OperationResponse operationResponse = new OperationResponse();
            operationResponse.OperationCode = message.Code;
            operationResponse.Parameters = new Dictionary<byte, object>();
            operationResponse.Parameters.Add(ResponseDataType.CODE, ResponseCode.SUCCESS);
            operationResponse.Parameters.Add(ResponseDataType.MESSAGE, LoginResponseMessage.SUCCESS);

           

            return true;
        }
    }
}
