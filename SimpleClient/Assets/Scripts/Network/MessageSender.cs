//APIs for send message
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class MessageSender : MonoBehaviour
{
    /**
    public static void MAvatar(byte[] pngData)
    {
        Debug.Log("M_AVATAR");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = pngData;
        NetworkController.sendMessage(MessageTag.M_AVATAR, msgData);

    }

    public static void MChat(string chatText)
    {
        Debug.Log("M_CHAT");
        chatText = chatText.Trim();
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = chatText;
        NetworkController.sendMessage(MessageTag.M_CHAT, msgData);
    }

    public static void MLogin(LoginType login_type, string username, string display_name, string facebook_id, string password, string version, string os, string device_id, string device_model, int cp_id)
    {
        Debug.Log("M_LOGIN");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = login_type;
        msgData[Const.Data2] = username;
        msgData[Const.Data3] = password;
        msgData[Const.Data4] = version;
        msgData[Const.Data5] = os;
        msgData[Const.Data6] = device_id;
        msgData[Const.Data7] = device_model;
        msgData[Const.Data8] = cp_id;
        msgData[Const.Data9] = GameController.DataConfigLoaded;
        msgData[Const.Data10] = display_name;
        msgData[Const.Data11] = facebook_id;
        NetworkController.sendMessage(MessageTag.M_LOGIN, msgData);
    }

    public static void MLogout()
    {
        Debug.Log("M_LOGOUT");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        NetworkController.sendMessage(MessageTag.M_LOGOUT, msgData);
    }

    public static void MRegister(Dictionary<byte, object> msgData)
    {
        Debug.Log("M_REGISTER");
        NetworkController.sendMessage(MessageTag.M_REGISTER, msgData);
    }

    public static void MGameListRequest()
    {
        Debug.Log("M_GAME_LIST_REQ");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        NetworkController.sendMessage(MessageTag.M_GAME_LIST_REQ, msgData);
    }

    public static void MRoomListRequest(GameCode game_id)
    {
        Debug.Log("M_ROOM_LIST_REQ");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = game_id;
        NetworkController.sendMessage(MessageTag.M_ROOM_LIST_REQ, msgData);
    }

    public static void MBoardListRequest(int roomId)
    {
        Debug.Log("M_BOARD_LIST_REQUEST");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = roomId;
        NetworkController.sendMessage(MessageTag.M_BOARD_LIST_REQUEST, msgData);
    }

    public static void MJoinBoard(int tableId, string passBoard = "")
    {
        Debug.Log("M_JOIN_BOARD_REQ");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = tableId;
        msgData[Const.Data2] = passBoard;
        NetworkController.sendMessage(MessageTag.M_JOIN_BOARD_REQUEST, msgData);
    }

    public static void MReady(bool ready)
    {
        Debug.Log("M_PLAYER_READY_REQ");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = ready;
        NetworkController.sendMessage(MessageTag.M_PLAYER_READY, msgData);
    }

    public static void MExitBoardRequest(bool show_loading = true)
    {
        if (show_loading) GameController.onLoading();
        Debug.Log("M_OPPONENT_EXIT_REQ");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        NetworkController.sendMessage(MessageTag.M_EXIT_BOARD_REQUEST, msgData);
    }

    public static void MBilling(TelcoCode telco_id, string serial, string card_code)
    {
        Debug.Log("M_BILLING_CARD");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = telco_id;
        msgData[Const.Data2] = serial;
        msgData[Const.Data3] = card_code;
        NetworkController.sendMessage(MessageTag.M_BILLING_CARD, msgData);
    }

    public static void MTurn(Dictionary<byte, object> msgData)
    {
        Debug.Log("M_TURN");
        NetworkController.sendMessage(MessageTag.M_TURN, msgData);
    }

    public static void MChatLobby(string message)
    {
        Debug.Log("M_CHAT_LOBBY");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = message;
        NetworkController.sendMessage(MessageTag.M_CHAT_LOBBY, msgData);
    }

    public static void MGetPlayerToInvite(InviteToPlayType invite_type)
    {
        Debug.Log("M_GET_PLAYERS_TO_INVITE");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = invite_type;
        NetworkController.sendMessage(MessageTag.M_GET_PLAYERS_TO_INVITE, msgData);
    }

    public static void MInviteToPlay(object invite_ids)
    {
        Debug.Log("M_INVITE_TO_PLAY");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = invite_ids;
        NetworkController.sendMessage(MessageTag.M_INVITE_TO_PLAY, msgData);
    }

    public static void MAcceptInviteToPlay(GameCode game_id, int room_id, int board_id)
    {
        Debug.Log("M_ACCEPT_INVITE_TO_PLAY");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = game_id;
        msgData[Const.Data2] = room_id;
        msgData[Const.Data3] = board_id;
        NetworkController.sendMessage(MessageTag.M_ACCEPT_INVITE_TO_PLAY, msgData);
    }

    public static void MQuickPlay()
    {
        Debug.Log("M_QUICK_PLAY");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        NetworkController.sendMessage(MessageTag.M_QUICK_PLAY, msgData);
    }

    public static void MKickPlayerOutBoard(int player_id)
    {
        Debug.Log("M_QUICK_PLAY");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = player_id;
        NetworkController.sendMessage(MessageTag.M_KICK_PLAYER_OUT_BOARD, msgData);
    }

    public static void MChangeBoardSetting(BoardSettingCode setting_code, object data)
    {
        Debug.Log("M_CHANGE_BOARD_SETTING");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = setting_code;
        msgData[Const.Data2] = data;
        NetworkController.sendMessage(MessageTag.M_CHANGE_BOARD_SETTING, msgData);
    }

    public static void MUpdateAlowInvitePlay(bool alow)
    {
        Debug.Log("M_UPDATE_ALOW_INVITE_PLAY");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = alow;
        NetworkController.sendMessage(MessageTag.M_UPDATE_ALOW_INVITE_PLAY, msgData);
    }

    public static void MUpdateUserInfos(string display_name, string status_text, string address, string phone_number)
    {
        Debug.Log("M_UPDATE_USER_INFOS");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = display_name;
        msgData[Const.Data2] = status_text;
        msgData[Const.Data3] = address;
        msgData[Const.Data4] = phone_number;
        NetworkController.sendMessage(MessageTag.M_UPDATE_USER_INFOS, msgData);
    }

    public static void MSendGift(int receive_id, GiftInBoardCode gift_id)
    {
        Debug.Log("M_SEND_GIFT");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = receive_id;
        msgData[Const.Data2] = gift_id;
        NetworkController.sendMessage(MessageTag.M_SEND_GIFT, msgData);
    }

    public static void MNotificationRegister(PlatformCode platform, string reg_Id)
    {
        Debug.Log("M_NOTIFICATION_REGISTER");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = (int)platform;
        msgData[Const.Data2] = reg_Id;
        NetworkController.sendMessage(MessageTag.M_NOTIFICATION_REGISTER, msgData);
    }

    public static void MTopBalanceRequest()
    {
        Debug.Log("M_TOP_BALANCE_REQUEST");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        NetworkController.sendMessage(MessageTag.M_TOP_BALANCE_REQUEST, msgData);
    }

    public static void MTopAchievementRequest()
    {
        Debug.Log("M_TOP_ACHIEVEMENT_REQUEST");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = GameController.CurrentGameId;
        NetworkController.sendMessage(MessageTag.M_TOP_ACHIEVEMENT_REQUEST, msgData);
    }

    public static void MSendBalance(string player_name, int balance)
    {
        Debug.Log("M_SEND_BALANCE");
        Dictionary<byte, object> msgData = new Dictionary<byte, object>();
        msgData[Const.Data1] = player_name;
        msgData[Const.Data2] = balance;
        NetworkController.sendMessage(MessageTag.M_SEND_BALANCE, msgData);
    }
    */
}
