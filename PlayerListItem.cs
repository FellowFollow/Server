using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    [SerializeField] Text text;
    
    public Player player {get; private set; }
    
    public string result = "Ready";

    public void SetUp(Player _player)
    {
        player = _player;
        SetPlayerText(_player);
    }
   
   public override void OnPlayerPropertiesUpdate(Player target, ExitGames.Client.Photon.Hashtable changedProps)
   {
       base.OnPlayerPropertiesUpdate(target, changedProps);
       if (target != null && target == player)
       {
           if(changedProps.ContainsKey("IsReady")) SetPlayerText(target);
       }
   }

   private void SetPlayerText(Player _player)
   {
       if(_player.CustomProperties.ContainsKey("IsReady"))
        result = (string)_player.CustomProperties["IsReady"];
        text.text = _player.NickName + " : " + result;
   }

   public override void OnPlayerLeftRoom(Player otherPlayer)
   {
       if (player == otherPlayer)
       {
           Destroy(gameObject);
       }
   }

    Player[] _isPlayer;
   public override void OnLeftRoom()
   {
        string exitinfo = "<color=#ff0000>" + "[System] The " + PhotonNetwork.LocalPlayer.NickName + " left the room" + "</color>";
        GameObject.Find("InroomManager").GetComponent<Inroom>().photonView.RPC("SendMess", RpcTarget.All, exitinfo);
        if (PhotonNetwork.LocalPlayer.IsMasterClient) 
        {
            foreach(var p in _isPlayer)
            {
                if(p!= PhotonNetwork.LocalPlayer)
                {
                    PhotonNetwork.CurrentRoom.SetMasterClient(p);
                    break;
                }
            }
            Destroy(gameObject);
        }

        else 
        {
            Destroy(gameObject);
        }
   }
}