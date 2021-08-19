/*************************************************************************
* @file         NHeal.cs                                                 *
* @details      노멀 모드의 체력 회복 아이템 사용 효과에 관한 스크립트.  *
*               키보드 1~3 중 해당하는 버튼을 누르면                     *
*               아이템 사용과 동시에 효과음이 재생되고                   *
*               플레이어의 체력을 회복시키는 HealHP()함수를 호출.        *
*                                                                        *
* ⓒ made by FellowFollow                                                *
*************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHeal : MonoBehaviour
{
    GameObject game;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("NormalModeDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            SoundManager.instance.SFXPlay("UseItem", clip);
            game.GetComponent<NormalDirector>().HealHP();
            Destroy(this.gameObject);
        }
    }
}
