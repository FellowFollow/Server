/***********************************************************************
* @file         NHalt.cs                                               *
* @details      노멀 모드의 공격중지 아이템 사용 효과에 관한 스크립트  *
*               키보드 1~3 중 해당하는 버튼을 누르면                   *
*               아이템 사용과 동시에 효과음이 재생되고                 *
*               장애물 없애는 UseDestroyItem() 함수를 가져와 호출.     *
*                                                                      *
* ⓒ made by FellowFollow                                              *
***********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHalt : MonoBehaviour
{
    GameObject wind;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.wind = GameObject.Find("windGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            SoundManager.instance.SFXPlay("UseItem", clip);
            wind.GetComponent<NWindGenerator>().windPrefab.gameObject.GetComponent<NWindController>().UseDestroyItem();
            Destroy(this.gameObject);
        }
    }
}
