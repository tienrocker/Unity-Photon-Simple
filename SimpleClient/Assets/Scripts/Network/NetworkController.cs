using Hashtable = ExitGames.Client.Photon.Hashtable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;

using UnityEngine;


public class NetworkController : MonoBehaviour, IPhotonPeerListener
{
    #region Info
    public string applicationName = "SimpleServer";
    public int applicationVersion = 1;

    public static NetworkController Instance;
    public NetworkPeer Peer { get; set; }

    private const int SEND_INTERVAL = 100;
    private int sendTickCount = Environment.TickCount;

    // address
    public enum SERVER_ADDRESS { LOCAL, TEST, };
    public SERVER_ADDRESS serverAddress;
    public string ServerEndPoint
    {
        get
        {
            switch (serverAddress)
            {
                case SERVER_ADDRESS.TEST: return "127.0.0.1:5055";
                default: return "127.0.0.1:5055";
            }
        }
    }

    // connection type
    public ConnectionProtocol connectionProtocol = ConnectionProtocol.Udp;
    #endregion

    // event
    public static event OnConnected onConnected;
    public static event OnDisconnected onDisconnected;
    public static event OnDisconnectByServer onDisconnectByServer;
    public static event OnDisconnectByServerLogic onDisconnectByServerLogic;
    public static event OnDisconnectByServerUserLimit onDisconnectByServerUserLimit;
    public static event OnEncryptionEstablished onEncryptionEstablished;
    public static event OnEncryptionFailedToEstablish onEncryptionFailedToEstablish;
    public static event OnException onException;
    public static event OnExceptionOnConnect onExceptionOnConnect;
    public static event OnExceptionOnReceive onExceptionOnReceive;
    [Obsolete("InternalReceiveException mark as deprecated by photon client sdk")]
    public static event OnInternalReceiveException onInternalReceiveException;
    public static event OnQueueIncomingReliableWarning onQueueIncomingReliableWarning;
    public static event OnQueueIncomingUnreliableWarning onQueueIncomingUnreliableWarning;
    public static event OnQueueOutgoingAcksWarning onQueueOutgoingAcksWarning;
    public static event OnQueueOutgoingReliableWarning onQueueOutgoingReliableWarning;
    public static event OnQueueOutgoingUnreliableWarning onQueueOutgoingUnreliableWarning;
    public static event OnQueueSentWarning onQueueSentWarning;
    public static event OnSecurityExceptionOnConnect onSecurityExceptionOnConnect;
    public static event OnSendError onSendError;
    [Obsolete("TcpRouterResponseEndpointUnknown mark as deprecated by photon client sdk")]
    public static event OnTcpRouterResponseEndpointUnknown onTcpRouterResponseEndpointUnknown;
    [Obsolete("TcpRouterResponseNodeIdUnknown mark as deprecated by photon client sdk")]
    public static event OnTcpRouterResponseNodeIdUnknown onTcpRouterResponseNodeIdUnknown;
    [Obsolete("TcpRouterResponseNodeNotReady mark as deprecated by photon client sdk")]
    public static event OnTcpRouterResponseNodeNotReady onTcpRouterResponseNodeNotReady;
    [Obsolete("TcpRouterResponseOk mark as deprecated by photon client sdk")]
    public static event OnTcpRouterResponseOk onOnTcpRouterResponseOk;
    public static event OnTimeoutDisconnect onTimeoutDisconnect;

    public virtual void Awake()
    {
        Instance = this;
        Peer = new NetworkPeer(this, connectionProtocol);
        enabled = false;

        // debug
        onConnected += () => DebugReturn(DebugLevel.INFO, "Connected");
        onDisconnected += () => DebugReturn(DebugLevel.INFO, "Disconnected");
    }

    public void Connect()
    {
        DebugReturn(DebugLevel.INFO, "Connecting...");
        if (Peer.Connect(ServerEndPoint, String.Format("{0} - {1}", applicationName, applicationVersion)))
        {
            enabled = true;
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Client.Instance.DebugText.text += String.Format("[{0}] {1} \n", level.ToString(), message);
        switch (level)
        {
            case DebugLevel.INFO:
                Debug.Log(message);
                break;
            case DebugLevel.ERROR:
                Debug.LogError(message);
                break;
            case DebugLevel.ALL:
                Debug.Log(message);
                break;
            case DebugLevel.WARNING:
                Debug.LogWarning(message);
                break;
            default:
                break;
        }
    }

    public void OnEvent(EventData eventData)
    {
        DebugReturn(DebugLevel.INFO, String.Format("OnEvent: {0}", eventData.ToStringFull()));
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {

        DebugReturn(DebugLevel.INFO, String.Format("OnOperationResponse: {0}", operationResponse.ToStringFull()));

        switch (operationResponse.OperationCode)
        {
            case SubCode.GLOBAL_ACTION_LOGIN:

                DebugReturn(DebugLevel.INFO, String.Format("OnOperationResponse: {0}", operationResponse.ToStringFull()));
                break;
            default:
                break;
        }

    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        switch (statusCode)
        {
            case StatusCode.Connect:
                if (onConnected != null) onConnected();
                break;
            case StatusCode.Disconnect:
                if (onDisconnected != null) onDisconnected();
                break;
            case StatusCode.DisconnectByServer:
                if (onDisconnectByServer != null) onDisconnectByServer();
                break;
            case StatusCode.DisconnectByServerLogic:
                if (onDisconnectByServerLogic != null) onDisconnectByServerLogic();
                break;
            case StatusCode.DisconnectByServerUserLimit:
                if (onDisconnectByServerUserLimit != null) onDisconnectByServerUserLimit();
                break;
            case StatusCode.EncryptionEstablished:
                if (onEncryptionEstablished != null) onEncryptionEstablished();
                break;
            case StatusCode.EncryptionFailedToEstablish:
                if (onEncryptionFailedToEstablish != null) onEncryptionFailedToEstablish();
                break;
            case StatusCode.Exception:
                if (onException != null) onException();
                break;
            case StatusCode.ExceptionOnConnect:
                if (onExceptionOnConnect != null) onExceptionOnConnect();
                break;
            case StatusCode.ExceptionOnReceive:
                if (onExceptionOnReceive != null) onExceptionOnReceive();
                break;
            case StatusCode.QueueIncomingReliableWarning:
                if (onQueueIncomingReliableWarning != null) onQueueIncomingReliableWarning();
                break;
            case StatusCode.QueueIncomingUnreliableWarning:
                if (onQueueIncomingUnreliableWarning != null) onQueueIncomingUnreliableWarning();
                break;
            case StatusCode.QueueOutgoingAcksWarning:
                if (onQueueOutgoingAcksWarning != null) onQueueOutgoingAcksWarning();
                break;
            case StatusCode.QueueOutgoingReliableWarning:
                if (onQueueOutgoingReliableWarning != null) onQueueOutgoingReliableWarning();
                break;
            case StatusCode.QueueOutgoingUnreliableWarning:
                if (onQueueOutgoingUnreliableWarning != null) onQueueOutgoingUnreliableWarning();
                break;
            case StatusCode.QueueSentWarning:
                if (onQueueSentWarning != null) onQueueSentWarning();
                break;
            case StatusCode.SecurityExceptionOnConnect:
                if (onSecurityExceptionOnConnect != null) onSecurityExceptionOnConnect();
                break;
            case StatusCode.SendError:
                if (onSendError != null) onSendError();
                break;
            case StatusCode.TimeoutDisconnect:
                if (onTimeoutDisconnect != null) onTimeoutDisconnect();
                break;
        }
    }

    public virtual void Update()
    {
        //Send update each SEND_INTERVAL
        if (Environment.TickCount > sendTickCount)
        {
            if (Peer == null)
            {
                Application.Quit();
            }
            Peer.Service();
            sendTickCount = Environment.TickCount + SEND_INTERVAL;
        }
    }

    public virtual void OnApplicationQuit()
    {
        Peer.Disconnect();
    }
}
