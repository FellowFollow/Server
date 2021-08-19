/*****************************************************************
* @file         HPBarScript.cs                                   *
* @details      플레이어의 현재 체력이 변할 때마다 계산하여      *
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

public class HPBarScript : MonoBehaviour
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
        this.game = GameObject.Find("EasyModeDirector");
        this.maxHP = this.game.GetComponent<EasyDirector>().maxHP;

        this.HPBar.value = (float)curHP / (float)maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.curHP = this.game.GetComponent<EasyDirector>().currentHP;
        this.coin = this.game.GetComponent<EasyDirector>().coin;
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
