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
    public InputField txtUsername;
    public InputField txtPassword;

    public UserData userData;
    #endregion

    #region Welcome
    public GameObject WelcomePanel;
    public Text WelcomeText;
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
            if (WelcomePanel != null) WelcomePanel.SetActive(false);
            if (btnReconnect != null) btnReconnect.gameObject.SetActive(false);
        };
        NetworkController.onDisconnected += () =>
        {
            if (LoginPanel != null) LoginPanel.SetActive(true);
            if (WelcomePanel != null) WelcomePanel.SetActive(false);
            if (btnReconnect != null) btnReconnect.gameObject.SetActive(true);
        };

        // connect to server
        NetworkController.Instance.Connect();
    }

    public void LoginClick()
    {
        NetworkController.Instance.DebugReturn(DebugLevel.INFO, String.Format("Login to system using username \"{0}\" and password \"{1}\"", txtUsername.text, txtPassword.text));

        if (txtUsername != null && txtPassword != null)
        {
            new LoginHandler().onRequest(txtUsername.text, txtPassword.text); // send login message to server
        }
    }

    public void ReconnectClick()
    {
        if (NetworkController.Instance.Peer.PeerState == PeerStateValue.Disconnected)
        {
            NetworkController.Instance.Connect();
        }
    }
}
