namespace SimpleServer
{
    using ExitGames.Logging;

    using Photon.SocketServer;

    using PhotonHostRuntimeInterfaces;
    using SimpleServerCommon;
    using System;
    using System.Collections.Generic;
    public class SimplePeer : PeerBase
    {
        public static List<SimplePeer> PeerLists = new List<SimplePeer>();
        public Guid PeerId { get; set; }
        private readonly ILogger Log;
        private IPhotonPeer photonPeer;
        private IRpcProtocol protocol;

        private List<IMessageHandler> handlers = new List<IMessageHandler>();

        public SimplePeer(IRpcProtocol protocol, IPhotonPeer photonPeer, ILogger log) : base(protocol, photonPeer)
        {
            this.protocol = protocol;
            this.photonPeer = photonPeer;
            Log = log;
            PeerId = Guid.NewGuid();
            PeerLists.Add(this);

            handlers.Add(new DefaultMessageHandler());
            handlers.Add(new LoginMessageHandler());
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            if (Log.IsDebugEnabled) Log.DebugFormat("OnDisconnect: conId={0}, reason={1}, reasonDetail={2}", this.ConnectionId, reasonCode, reasonDetail);
            PeerLists.Remove(this);
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            if (Log.IsDebugEnabled)
            {
                Log.DebugFormat("OnOperationRequest: conId={0}, operationCode={1}, parameters={2}", this.ConnectionId, operationRequest.OperationCode, operationRequest.Parameters);
            }

            DefaultMessage msg = new DefaultMessage();
            msg.Code = operationRequest.OperationCode;
            msg.SubCode = operationRequest.Parameters.TryGetValue()

            foreach (IMessageHandler handler in handlers)
            {
                if (handler.HandlerMessage(msg))
                {
                    break;
                }
            }

            // simple login action
            if (operationRequest.OperationCode == OperationCode.GLOBAL_ACTION_LOGIN)
            {
                string username = operationRequest.Parameters[LoginRequestData.LOGIN_DATA_USERNAME].ToString();
                string password = operationRequest.Parameters[LoginRequestData.LOGIN_DATA_PASSWORD].ToString();

                OperationResponse operationResponse = new OperationResponse();
                operationResponse.OperationCode = operationRequest.OperationCode;
                operationResponse.Parameters = new Dictionary<byte, object>();
                operationResponse.Parameters.Add(LoginResponseData.CODE, LoginResponseCode.SUCCESS);
                operationResponse.Parameters.Add(LoginResponseData.MESSAGE, LoginResponseMessage.SUCCESS);
                SendMessage(operationResponse);

                Dictionary<byte, object> parameters = new Dictionary<byte, object>();
                parameters.Add(EventType.MESSAGE, string.Format("{0}: {1} logged in", PeerId, username));
                EventData eventData = new EventData(EventType.MESSAGE, parameters);
                SendOtherMessage(eventData);
            }
        }

        public void SendMessage(OperationResponse operationResponse)
        {
            SendOperationResponse(operationResponse, new SendParameters());
        }

        public void SendOtherMessage(OperationResponse operationResponse)
        {
            foreach (SimplePeer peer in PeerLists)
            {
                if (peer == this) continue;
                peer.SendMessage(operationResponse);
            }
        }

        public void SendEventData(EventData eventData)
        {
            SendEvent(eventData, new SendParameters());
        }

        public void SendOtherMessage(EventData eventData)
        {
            foreach (SimplePeer peer in PeerLists)
            {
                if (peer == this) continue;
                peer.SendEventData(eventData);
            }
        }
    }
}