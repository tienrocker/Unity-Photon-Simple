using System;

public delegate void OnConnected();
public delegate void OnDisconnected();
public delegate void OnDisconnectByServer();
public delegate void OnDisconnectByServerLogic();
public delegate void OnDisconnectByServerUserLimit();
public delegate void OnEncryptionEstablished();
public delegate void OnEncryptionFailedToEstablish();
public delegate void OnException();
public delegate void OnExceptionOnConnect();
public delegate void OnExceptionOnReceive();
[Obsolete("InternalReceiveException mark as deprecated by photon client sdk")]
public delegate void OnInternalReceiveException();
public delegate void OnQueueIncomingReliableWarning();
public delegate void OnQueueIncomingUnreliableWarning();
public delegate void OnQueueOutgoingAcksWarning();
public delegate void OnQueueOutgoingReliableWarning();
public delegate void OnQueueOutgoingUnreliableWarning();
public delegate void OnQueueSentWarning();
public delegate void OnSecurityExceptionOnConnect();
public delegate void OnSendError();
[Obsolete("TcpRouterResponseEndpointUnknown mark as deprecated by photon client sdk")]
public delegate void OnTcpRouterResponseEndpointUnknown();
[Obsolete("TcpRouterResponseNodeIdUnknown mark as deprecated by photon client sdk")]
public delegate void OnTcpRouterResponseNodeIdUnknown();
[Obsolete("TcpRouterResponseNodeNotReady mark as deprecated by photon client sdk")]
public delegate void OnTcpRouterResponseNodeNotReady();
[Obsolete("TcpRouterResponseOk mark as deprecated by photon client sdk")]
public delegate void OnTcpRouterResponseOk();
public delegate void OnTimeoutDisconnect();