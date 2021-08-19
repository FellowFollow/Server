/**************************************************************
* @file     HReflection.cs                                    *
* @details  HardScene의 공격 아이템의 사용을 다루는 소스파일  *
*                                                             *
* ⓒ made by FellowFollow                                     *
**************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HReflection : MonoBehaviour
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
