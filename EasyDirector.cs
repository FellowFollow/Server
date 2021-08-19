/*****************************************************************
* @file         EasyDirector.cs                                  *
* @details      이지모드를 총괄하는 Game Director                *
*               코인(점수)를 표시하며                            *
*               hp증감, 점수 올리기 등 여러 함수를 포함 .        *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Pun;
using Photon.Realtime;

public class EasyDirector : MonoBehaviourPunCallbacks
{
    public PhotonView enemyHPsync;
    
    public AudioClip clip;

    GameObject score;
    public int coin = 0;
    public static int coinScore;

    public float maxHP = 100;
    public float currentHP = 100;

    public float e_maxHP = 100;
    public float e_currentHP = 100;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
        SoundManager.instance.SFXPlay("coin", clip);
    }

    public void DecreaseHp()
    {
        currentHP -= 10;
    }

    public void HealHP()
    {
        currentHP += 10;
    }

    public void AttackEnemy()
    {
        e_currentHP -= 10;
    }

    public void ScorePoint()
    {
        coin++;
    }

    // Update is called once per frame
    void Update()
    {
        score.GetComponent<Text>().text = this.coin.ToString("F0");
        PlayerPrefs.SetFloat("score", this.coin);
        coinScore = coin;
    }
}
