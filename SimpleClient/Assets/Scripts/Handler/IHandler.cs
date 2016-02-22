using ExitGames.Client.Photon;

public interface IHandler
{
    byte Code();
    void onResponse(OperationResponse operationResponse, IPhotonPeerListener peer);
}