namespace SimpleServer
{
    using ExitGames.Logging;
    using Photon.SocketServer;
    using PhotonHostRuntimeInterfaces;
    using System;
    using System.Collections.Generic;

    public class SimplePeer : PeerBase, IClientPeer
    {
        public static List<SimplePeer> PeerLists = new List<SimplePeer>();
        public Guid PeerId { get; set; }
        public bool IsProxy { get { return false; } set { /* do nothing */ } }
        private readonly ILogger Log;
        private IPhotonPeer photonPeer;
        private IRpcProtocol protocol;

        private List<IHandler<IClientPeer>> handlers = new List<IHandler<IClientPeer>>();
        private readonly IHandlerList<IClientPeer> handlerList;

        public SimplePeer(IRpcProtocol protocol, IPhotonPeer photonPeer, ILogger log) : base(protocol, photonPeer)
        {
            this.protocol = protocol;
            this.photonPeer = photonPeer;
            Log = log;
            PeerId = Guid.NewGuid();
            PeerLists.Add(this);

            // add handler
            handlers.Add(new LoginRequestHandler());
            handlers.Add(new RegisterRequestHandler());
            handlerList = new ClientHandlerList(handlers);
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

            handlerList.HandlerMessage(new RequestMessage(operationRequest.OperationCode, operationRequest.Parameters), this);
        }
        
        T IClientPeer.ClientData<T>()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(IMessage message)
        {
            if (message is EventMessage)
            {
                SendEvent(new EventData(message.Code) { Parameters = message.Parameters }, new SendParameters());
            }

            var response = message as ResponseMessage;
            if (response != null)
            {
                SendOperationResponse(new OperationResponse(response.Code, response.Parameters) { DebugMessage = response.DebugMessage, ReturnCode = response.ReturnCode }, new SendParameters());
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