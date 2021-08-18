/************************************************************************************
* @file     Inroom.cs                                                               *
* @details  플레이어가 입장한 대기방의 기능 구현                                      *
*           먼저 입장한 플레이어를 방장으로 인식                                      *
*                                                                                   *
* ⓒ made by FellowFollow                                                           *
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Inroom : MonoBehaviourPunCallbacks
{
    public GameObject readyBtn;
    public GameObject startBtn;

    //플레이어의 상태를 출력하는 기능
    public Transform readyContent;
    public GameObject statusPrefab;

    #region Mono function

    //방장인지를 판단하여 Gamestart버튼과 Ready버튼 활성화 설정
    private void Update()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            readyBtn.SetActive(false);
            startBtn.SetActive(true);
        }
        else
        {
            readyBtn.SetActive(true);
            startBtn.SetActive(false);
        }
    }
    #endregion

    #region Button function
    [PunRPC]
    void SendMess(string message)
    {
        GameObject textobj = Instantiate(statusPrefab, readyContent);
        textobj.GetComponent<Text>().text = message;
    }

    //GameStart 버튼
    public void SetStart()
    {
        photonView.RPC("LoadGameScene", RpcTarget.All);
    }
    
    [PunRPC]
    void LoadGameScene()
    {
        PhotonNetwork.LoadLevel(1);
    }
    #endregion
}
