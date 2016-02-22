using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using System;

public class Client : MonoBehaviour
{
    #region Debug
    public static Client Instance;
    public Text DebugText;
    #endregion

    #region Reconnect
    public Button btnReconnect;
    #endregion

    #region Login
    public GameObject LoginPanel;
    public Button btnLogin;
    public Text txtUsername;
    public Text txtPassword;

    public UserData userData;
    #endregion

    void Awake()
    {
        Instance = this;
        if (btnLogin != null) btnLogin.onClick.AddListener(this.LoginClick);
        if (btnReconnect != null) btnReconnect.onClick.AddListener(this.ReconnectClick);
        Application.runInBackground = true;
    }

    void Start()
    {
        // assign event
        NetworkController.onConnected += () =>
        {
            if (LoginPanel != null) LoginPanel.SetActive(true);
            if (btnReconnect != null) btnReconnect.gameObject.SetActive(false);
        };
        NetworkController.onDisconnected += () =>
        {
            if (btnReconnect != null) btnReconnect.gameObject.SetActive(true);
        };

        // connect to server
        NetworkController.Instance.Connect();
    }

    public void LoginClick()
    {
        NetworkController.Instance.DebugReturn(DebugLevel.INFO, String.Format("Login to system using username \"{0}\" and password \"{1}\"", txtUsername.text, txtPassword.text));

        // send login message to server
        NetworkController.onOperationResponse += (new LoginHandler().onOperationResponse); // assign response processer

        Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>();
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_TYPE, LoginRequestData.LoginType.NORMAL);
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_USERNAME, txtUsername.text);
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_PASSWORD, txtPassword.text);
        NetworkController.Instance.Peer.OpCustom(RequestCode.GLOBAL_ACTION_LOGIN, customOpParameters, true);
    }

    public void ReconnectClick()
    {
        if (NetworkController.Instance.Peer.PeerState == PeerStateValue.Disconnected)
        {
            NetworkController.Instance.Connect();
        }
    }
}
