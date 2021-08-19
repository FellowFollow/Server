/*****************************************************************
* @file         NWindGenerator.cs                                *
* @details      Normal Mode                                      *
*               일정 시간마다 효과음과 함께 장애물을 생성한다.   *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWindGenerator : MonoBehaviour
{
    public GameObject windPrefab;
    public AudioClip clip;
    float span = 5.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(windPrefab) as GameObject;
            SoundManager.instance.SFXPlay("wind", clip);
            go.transform.position = new Vector3(10, -3.6f, 0);
        }
    }
}
