/**********************************************************************
* @file HHPBarScript.cs                                               *
* @details  HardScene 플레이어의 체력과 관련된 함수를 다루는 소스파일 *
*                                                                     *
* ⓒ made by FellowFollow                                             *
***********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HHPBarScript : MonoBehaviour
{
    GameObject game;

    [SerializeField]
    private Slider HPBar;
    float maxHP;
    float curHP;
    int coin;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("HardModeDirector");
        this.maxHP = this.game.GetComponent<HardDirector>().maxHP;
        //this.curHP = this.game.GetComponent<HardDirector>().currentHP;

        this.HPBar.value = (float)curHP / (float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.coin = this.game.GetComponent<HardDirector>().coin;
        this.curHP = this.game.GetComponent<HardDirector>().currentHP;
        FailScoreManager.coin = this.coin;

        HandleHP();

        if (this.HPBar.value <= 0)
        {
            SceneManager.LoadScene("FailScene");
        }
    }

    private void HandleHP()
    {
        this.HPBar.value = (float)curHP / (float)maxHP;
    }
}
