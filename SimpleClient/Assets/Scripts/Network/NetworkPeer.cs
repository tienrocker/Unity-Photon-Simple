using System.Collections.Generic;
using ExitGames.Client.Photon;

public class NetworkPeer : PhotonPeer
{
    public NetworkPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType) : base(listener, protocolType)
    {

    }     
}