using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class UIController : MonoBehaviour
{
    [Header("Nickname")]
    public Text txtMessage;
   
    public GameObject panelNickname;
    public InputField txtNickname;
    public int minLengtNick = 3;

    [Header("Lobby")]

    public GameObject panelLobby;
    public InputField txtRoomName;
    public Text txtServerData;
    public GameObject prefabRoomItem;
    public Transform parentRoomItem;


    private UILog uILog;
    private GameController gameController;
    void Start()
    {
        uILog = GetComponent<UILog>();
        gameController = GetComponent<GameController>();
        txtMessage.text = string.Empty;
        panelNickname.SetActive(true);
        GetNickName();


    }

    #region "UI EVENTS"


    public void OnClick_nickName()
    {
        if (txtNickname.text.Length < minLengtNick)
        {
            uILog.setText("Nickname  invalido, min " + minLengtNick);
            return;
        }
        SetNickName();
        panelNickname.SetActive(false);
        txtMessage.text = "LOADING...";
        uILog.setText(string.Empty);
        gameController.StartConnection(txtNickname.text);

    }


    #endregion


    private void GetNickName()
    {
        if (PlayerPrefs.HasKey("NICK"))
            txtNickname.text = PlayerPrefs.GetString("NICK");
    }

    private void SetNickName()
    {
        PlayerPrefs.SetString("NICK", txtNickname.text);
    }
    public void ShowLobbyPanel(bool show = true)
    {
        if (show)
        {
            panelLobby.SetActive(true);
            txtMessage.text = string.Empty;
        }
        else
        {
            panelLobby.SetActive(false);

        }
    }


    public void ShowLog(string s)
    {
        uILog.setText(s);
    }

    public void ShowMessage(string s)
    {
        txtMessage.text = s;
    }
    public void ShowServerData(string d)
    {
        txtServerData.text = d;
    }
    public void UpdateRoomList(List<RoomInfo> roomList)
    {
        //      prefabRoomItem

        foreach (RoomInfo ri in roomList)
        {
            RoomItem roomItem = Instantiate(prefabRoomItem, parentRoomItem.position, parentRoomItem.rotation, parentRoomItem).GetComponent<RoomItem>();
            roomItem.UpdateRoom(ri.Name, ri.MaxPlayers, ri.PlayerCount, this);
        }
    }

    public void OnClick_CreateRoom()
    {
        if (txtRoomName.text.Length < 3)
            return;

        gameController.CreateRoom(txtRoomName.text, true);
    }

    public void OnClick_JoinRoom(string roomName)
    {
        if (roomName.Length < 3)
            return;

        gameController.CreateRoom(roomName, false);
    }
}
