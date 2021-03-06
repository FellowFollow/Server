/*****************************************************************
* @file         NHPBarScript.cs                                  *
* @details      Normal Mode                                      *
*               플레이어의 현재 체력이 변할 때마다 계산하여      *
*               Slider에 변화를 적용한다.                        *
*               플레이어의 체력이 0이 되면 FailScene으로 전환.   *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NHPBarScript : MonoBehaviour
{
    GameObject game;

    [SerializeField]
    private Slider HPBar;
    float maxHP;
    float curHP;
    public int coin;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("NormalModeDirector");
        this.maxHP = this.game.GetComponent<NormalDirector>().maxHP;
        //this.curHP = this.game.GetComponent<NormalDirector>().currentHP;

        this.HPBar.value = (float)curHP / (float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.coin = this.game.GetComponent<NormalDirector>().coin;
        this.curHP = this.game.GetComponent<NormalDirector>().currentHP;
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
