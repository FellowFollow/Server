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

    public Transform readyContent;
    public GameObject statusPrefab;

    #region Mono function

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
