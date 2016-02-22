using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LoginHandler : IHandler
{
    public byte Code()
    {
        return RequestCode.GLOBAL_ACTION_LOGIN;
    }

    /// <summary>
    /// Login request
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public void onRequest(string username, string password)
    {
        NetworkController.onOperationResponse += this.onResponse; // assign response processer

        Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>();
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_TYPE, LoginRequestData.LoginType.NORMAL);
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_USERNAME, username);
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_PASSWORD, password);
        NetworkController.Instance.Peer.OpCustom(RequestCode.GLOBAL_ACTION_LOGIN, customOpParameters, true);
    }

    /// <summary>
    /// Login response
    /// </summary>
    /// <param name="operationResponse"></param>
    /// <param name="peer"></param>
    public void onResponse(OperationResponse operationResponse, IPhotonPeerListener peer)
    {
        // login process
        if (operationResponse.OperationCode == Code())
        {
            NetworkController.onOperationResponse -= this.onResponse;
            if ((byte)operationResponse.Parameters[ResponseDataType.CODE] == ResponseCode.SUCCESS)
            {
                Debug.LogFormat("User Info: {0} {1} {2} {3} {4}",
                    operationResponse.Parameters[ResponseDataType.DATA1],
                    operationResponse.Parameters[ResponseDataType.DATA2],
                    operationResponse.Parameters[ResponseDataType.DATA3],
                    operationResponse.Parameters[ResponseDataType.DATA4],
                    operationResponse.Parameters[ResponseDataType.DATA5]
                );

                // assign user data
                Client.Instance.userData = new UserData(
                    (int)operationResponse.Parameters[ResponseDataType.DATA1],
                    (string)operationResponse.Parameters[ResponseDataType.DATA2],
                    (string)operationResponse.Parameters[ResponseDataType.DATA3],
                    (string)operationResponse.Parameters[ResponseDataType.DATA4],
                    (string)operationResponse.Parameters[ResponseDataType.DATA5]
                );

                if (Client.Instance.LoginPanel != null) Client.Instance.LoginPanel.SetActive(false);
                if (Client.Instance.WelcomePanel != null)
                {
                    Client.Instance.WelcomePanel.SetActive(true);
                    if (Client.Instance.WelcomeText != null) Client.Instance.WelcomeText.text = String.Format("Welcome {0}", Client.Instance.userData.Username);
                }
            }
            else {
                Debug.LogFormat("Login: {0} {1}", operationResponse.Parameters[ResponseDataType.CODE], operationResponse.Parameters[ResponseDataType.MESSAGE]);
            }
        }
    }
}