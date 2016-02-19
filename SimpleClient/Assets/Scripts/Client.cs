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

    #region Login
    public GameObject LoginPanel;
    public Button btnLogin;
    public Text txtUsername;
    public Text txtPassword;
    #endregion

    void Awake()
    {
        Instance = this;
        if (LoginPanel != null) LoginPanel.SetActive(false);
        if (btnLogin != null) btnLogin.onClick.AddListener(this.LoginClick);
    }

    void Start()
    {
        // assign event
        NetworkController.onConnected += () => { if (LoginPanel != null) LoginPanel.SetActive(true); };

        // connect to server
        NetworkController.Instance.Connect();
    }

    public void LoginClick()
    {
        NetworkController.Instance.DebugReturn(DebugLevel.INFO, String.Format("Login to system using username \"{0}\" and password \"{1}\"", txtUsername.text, txtPassword.text));

        // send login message to server
        Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>();
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_TYPE, LoginRequestData.LoginType.NORMAL);
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_USERNAME, txtUsername.text);
        customOpParameters.Add(LoginRequestData.LOGIN_DATA_PASSWORD, txtPassword.text);
        NetworkController.Instance.Peer.OpCustom(SubCode.GLOBAL_ACTION_LOGIN, customOpParameters, true);
    }

}
