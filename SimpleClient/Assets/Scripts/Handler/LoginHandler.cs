using ExitGames.Client.Photon;
using System;
using UnityEngine;

public class LoginHandler : IHandler
{
    public void onOperationResponse(OperationResponse operationResponse, IPhotonPeerListener peer)
    {
        // login process
        if (operationResponse.OperationCode == RequestCode.GLOBAL_ACTION_LOGIN)
        {
            NetworkController.onOperationResponse -= this.onOperationResponse;
            if ((byte)operationResponse.Parameters[ResponseDataType.CODE] == ResponseCode.SUCCESS)
            {
                Debug.LogFormat("User Info: {0} {1} {2} {3} {4}",
                    operationResponse.Parameters[ResponseDataType.DATA1],
                    operationResponse.Parameters[ResponseDataType.DATA2],
                    operationResponse.Parameters[ResponseDataType.DATA3],
                    operationResponse.Parameters[ResponseDataType.DATA4],
                    operationResponse.Parameters[ResponseDataType.DATA5]
                );

                Client.Instance.userData = new UserData(
                    (int)operationResponse.Parameters[ResponseDataType.DATA1],
                    (string)operationResponse.Parameters[ResponseDataType.DATA2],
                    (string)operationResponse.Parameters[ResponseDataType.DATA3],
                    (string)operationResponse.Parameters[ResponseDataType.DATA4],
                    (string)operationResponse.Parameters[ResponseDataType.DATA5]
                );
            }
            else {
                Debug.LogFormat("Login: {0} {1}", operationResponse.Parameters[ResponseDataType.CODE], operationResponse.Parameters[ResponseDataType.MESSAGE]);
            }
        }
    }
}