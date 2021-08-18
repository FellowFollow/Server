/***********************************************************************
* @file         ReadyCustom.cs                                         *                                     
* @details      플레이어 리스트의 레디 여부 텍스트를 조정하는 기능        *
*               HashTable에서 플레이어를 찾아 데이터를 수정.             *
*                                                                      *
* ⓒ made by FellowFollow                                              *
***********************************************************************/
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyCustom : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    public string result;

    void Start() {
        result = "Ready";
    }

    private void SetCustomText(string result)
    {
        _myCustomProperties["IsReady"] = result;

        _text.text = PhotonNetwork.LocalPlayer.NickName + " : " + result;
        PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties);
    }

    //플레이어가 레디버튼을 눌러 상태를 변경할 경우
    public void OnClick_Waiting()
    {
        if(result == "Ready") result = "Waiting";
        else result = "Ready";

        string readyInfo = "<color=#00EDFF>" + "[Player] The " + PhotonNetwork.LocalPlayer.NickName + " : " + result+  "</color>";
        GameObject.Find("InroomManager").GetComponent<Inroom>().photonView.RPC("SendMess", RpcTarget.All, readyInfo);

        SetCustomText(result);
    }
}
