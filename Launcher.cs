/*************************************************************************************
* @file         Launcher.cs                                                          *
* @details      로비 기능 구현                                                        *                                                      
*               플레이어가 방을 선택&생성 하면 패널을 전환하여 방에 입장하도록 함        *
*                                                                                    *
* ⓒ made by FellowFollow                                                            *
**************************************************************************************/
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher _instance;
    //로비 패널
    public GameObject Lobby;
    public InputField RoomNameInput;

    public GameObject buttonRoom;
    public GameObject CreateOrJoinRoomBtn;
    public GameObject tabRooms;

    private List<RoomInfo> roomList;

    //대기방 패널
    public GameObject InRoom;
    public Text roomTitle;
    public Transform playerlistContent;
    public GameObject Playerprefab;

    //서버 연동 함수
    public void Awake() 
    {
        if(_instance == null) _instance = this;
    }

    public void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined to Lobby");
        tabRooms.SetActive(true);
    }

    //방 생성 후 입장 Create()
    //빠른 시작, 아무 방이나 들어가는 JoinRandom()
    public void Create() {
        if(string.IsNullOrEmpty(RoomNameInput.text)) {
            return;
        }

        PhotonNetwork.CreateRoom(RoomNameInput.text, new RoomOptions { MaxPlayers = 4, IsVisible = true, BroadcastPropsChangeToAll = true});

        Lobby.SetActive(false);
        InRoom.SetActive(true);
    }

    public void JoinRandom()
    {
        PhotonNetwork.JoinRandomRoom();

        Lobby.SetActive(false);
        InRoom.SetActive(true);
    }

    //방 목록 
    public void ClearRoomList()
    {
        Transform content = tabRooms.transform.Find("Scroll View/Viewport/Content");

        foreach (Transform a in content)
        {
            Destroy(a.gameObject);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> p_list)
    {
        roomList = p_list;
        ClearRoomList();

        Debug.Log("LOADED ROOMS @ " + Time.time);

        Transform content = tabRooms.transform.Find("Scroll View/Viewport/Content");
        
        foreach (RoomInfo a in roomList)
        {
                GameObject newRoomButton = Instantiate(buttonRoom, content) as GameObject;

                if(a.PlayerCount == 0)
                {
                    roomList.Remove(a);
                }
                else {
                    newRoomButton.transform.Find("Name").GetComponent<Text>().text = a.Name;
                    newRoomButton.transform.Find("Players").GetComponent<Text>().text = a.PlayerCount + " / " + a.MaxPlayers;
                }
            newRoomButton.GetComponent<Button>().onClick.AddListener(delegate { JoinRoom(newRoomButton.transform); });
        }

        base.OnRoomListUpdate(roomList);
    }

    public void JoinRoom(Transform p_button)
    {
        Debug.Log("JOINING ROOM @" + Time.time);
        string t_roomName = p_button.Find("Name").GetComponent<Text>().text;
        PhotonNetwork.JoinRoom(t_roomName);

        Lobby.SetActive(false);
        InRoom.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        roomTitle.text = PhotonNetwork.CurrentRoom.Name;

        Player[] allplayers = PhotonNetwork.PlayerList;
   
        for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            Instantiate(Playerprefab, playerlistContent).GetComponent<PlayerListItem>().SetUp(allplayers[i]);
        }

        string joininfo = "<color=#00ff00>" + "[System] The " + PhotonNetwork.LocalPlayer.NickName + " is on the room" +  "</color>";
        GameObject.Find("InroomManager").GetComponent<Inroom>().photonView.RPC("SendMess", RpcTarget.All, joininfo);

        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(Playerprefab, playerlistContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    //방에서 나감
    public void exit()
    {
        string exitinfo = "<color=#ff0000>" + "[System] The " + PhotonNetwork.LocalPlayer.NickName + " exit the room" + "</color>";
        GameObject.Find("InroomManager").GetComponent<Inroom>().photonView.RPC("SendMess", RpcTarget.All, exitinfo);

        PhotonNetwork.LeaveRoom(true);
        
        InRoom.SetActive(false);
        Lobby.SetActive(true);
    }
}
