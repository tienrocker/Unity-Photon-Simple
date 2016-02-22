using ExitGames.Client.Photon;

public interface IHandler
{
    void onOperationResponse(OperationResponse operationResponse, IPhotonPeerListener peer);
}