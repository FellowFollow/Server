/**************************************************************************
* @file     HHalt.cs                                                      *
* @details  HardScene의 보스 공격 무효화 아이템의 사용을 다루는 소스파일  *
*                                                                         *
* ⓒ made by FellowFollow                                                 *
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHalt : MonoBehaviour
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
            wind.GetComponent<HWindGenerator>().windPrefab.gameObject.GetComponent<HWindController>().UseDestroyItem();
            Destroy(this.gameObject);
        }
    }
}
