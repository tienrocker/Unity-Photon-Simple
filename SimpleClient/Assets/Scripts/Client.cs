using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Client : MonoBehaviour
{
    #region Login
    public GameObject LoginPanel;
    public Button btnLogin;
    public Text txtUsername;
    public Text txtPassword;
    #endregion

    void Awake()
    {
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
        Debug.LogFormat("Login to system using username \"{0}\" and password \"{1}\"", txtUsername.text, txtPassword.text);

        // send login message to server
        Dictionary<byte, object> customOpParameters = new Dictionary<byte, object>();
        customOpParameters.Add(LoginData.LOGIN_DATA_TYPE, LoginType.NORMAL);
        customOpParameters.Add(LoginData.LOGIN_DATA_USERNAME, txtUsername.text);
        customOpParameters.Add(LoginData.LOGIN_DATA_PASSWORD, txtPassword.text);
        NetworkController.Instance.Peer.SendMessage(SubCode.GLOBAL_ACTION_LOGIN, customOpParameters);
    }

}
