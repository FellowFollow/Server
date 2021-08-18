/**********************************************************************
* @file HardDirector.cs                                               *
* @details  HardScene의 HP 변동과 모은 코인, 씬 이동을 다룬 소스파일  *
*                                                                     *
* ⓒ made by FellowFollow                                             *
***********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HardDirector : MonoBehaviour
{
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
