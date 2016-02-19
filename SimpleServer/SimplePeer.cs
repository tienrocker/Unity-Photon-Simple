// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyPeer.cs" company="Exit Games GmbH">
//   Copyright (c) Exit Games GmbH.  All rights reserved.
// </copyright>
// <summary>
//   Defines the MyPeer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SimpleServer
{
    using ExitGames.Logging;

    using Photon.SocketServer;

    using PhotonHostRuntimeInterfaces;
    using System.Collections.Generic;
    public class SimplePeer : PeerBase
    {
        private readonly ILogger Log;
        private IPhotonPeer photonPeer;
        private IRpcProtocol protocol;

        public SimplePeer(IRpcProtocol protocol, IPhotonPeer photonPeer, ILogger log) : base(protocol, photonPeer)
        {
            this.protocol = protocol;
            this.photonPeer = photonPeer;
            Log = log;
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            if (Log.IsDebugEnabled)
            {
                Log.DebugFormat("OnDisconnect: conId={0}, reason={1}, reasonDetail={2}", this.ConnectionId, reasonCode, reasonDetail);
            }
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            if (Log.IsDebugEnabled)
            {
                Log.DebugFormat("OnOperationRequest: conId={0}, operationCode={1}, parameters={2}", this.ConnectionId, operationRequest.OperationCode, operationRequest.Parameters);
            }

            // simple login action
            if (operationRequest.OperationCode == SubCode.GLOBAL_ACTION_LOGIN)
            {
                OperationResponse operationResponse = new OperationResponse();
                operationResponse.OperationCode = operationRequest.OperationCode;
                operationResponse.Parameters = new System.Collections.Generic.Dictionary<byte, object>();
                operationResponse.Parameters.Add(LoginResponseData.LOGIN_DATA_SUCCESS, "Login Success");
                SendOperationResponse(operationResponse, new SendParameters());

                Dictionary<byte, object> parameters = new Dictionary<byte, object>();
                parameters.Add(LoginResponseData.LOGIN_DATA_SUCCESS, string.Format("{0} logged in", operationRequest.Parameters[LoginRequestData.LOGIN_DATA_USERNAME]));
                EventData eventData = new EventData(LoginResponseData.LOGIN_DATA_SUCCESS, parameters);
                SendEvent(eventData, new SendParameters());
            }
        }
    }
}