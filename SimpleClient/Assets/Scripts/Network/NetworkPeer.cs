using System.Collections.Generic;
using ExitGames.Client.Photon;

public class NetworkPeer : PhotonPeer
{
    public NetworkPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType) : base(listener, protocolType)
    {

    }

    public void SendMessage(int subCode, Dictionary<byte, object> customOpParameters)
    {
        //Assign tag
        customOpParameters[MessageSubCode.KINGPLAY_OPERATION_TAG] = subCode;

        //Send to server
        OpCustom(MessageCode.KINGPLAY_OPERATION_CODE, customOpParameters, true);
    }

    public override bool OpCustom(byte customOpCode, Dictionary<byte, object> customOpParameters, bool sendReliable)
    {
        return base.OpCustom(customOpCode, customOpParameters, sendReliable);
    }
}

public static class MessageCode
{
    public const byte KINGPLAY_OPERATION_CODE = 200;
}

public static class MessageSubCode
{
    public const byte KINGPLAY_OPERATION_TAG = 100;
}
