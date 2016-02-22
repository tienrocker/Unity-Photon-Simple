using Photon.SocketServer;
using System;
using System.Collections.Generic;

namespace SimpleServer
{
    public class LoginRequestHandler : ClientHandler
    {
        public override byte Code
        {
            get
            {
                return RequestCode.GLOBAL_ACTION_LOGIN;
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

            Dictionary<byte, object> pr = new Dictionary<byte, object>();

            // check password
            if (username == "test" && password == "test")
            {
                pr.Add(ResponseDataType.CODE, ResponseCode.SUCCESS);
                pr.Add(ResponseDataType.MESSAGE, LoginResponseMessage.SUCCESS);

                UserData userData = new UserData(0, username, password, "", "no");
                pr.Add(ResponseDataType.DATA1, userData.Id);
                pr.Add(ResponseDataType.DATA2, userData.UserName);
                pr.Add(ResponseDataType.DATA3, userData.Password);
                pr.Add(ResponseDataType.DATA4, userData.Email);
                pr.Add(ResponseDataType.DATA5, userData.Banned);
            }
            else {
                pr.Add(ResponseDataType.CODE, ResponseCode.FAILED);
                pr.Add(ResponseDataType.MESSAGE, LoginResponseMessage.FAILED);
            }

            ResponseMessage rm = new ResponseMessage(message.Code, pr);
            peer.SendMessage(rm);

            return true;
        }
    }
}
