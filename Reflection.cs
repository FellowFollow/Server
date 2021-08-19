/***********************************************************************
* @file         Reflection.cs                                          *
* @details      공격 아이템 사용 효과에 관한 스크립트                  *
*               키보드 1~3 중 해당하는 버튼을 누르면                   *
*               아이템 사용과 동시에 효과음이 재생되고                 *
*               보스를 공격하는 검기를 발사하는 Attack() 함수를 호출   *
*                                                                      *
* ⓒ made by FellowFollow                                              *
***********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    GameObject effect;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.effect = GameObject.Find("EffectGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            effect.GetComponent<EffectGenerator>().Attack();
            SoundManager.instance.SFXPlay("attack", clip);
            Destroy(this.gameObject);
        }
    }
}
