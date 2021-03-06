/*****************************************************************
* @file         NHealGenerator.cs                                *
* @details      Normal Mode                                      *
*               일정 시간마다 체력 회복 아이템을 생성한다.       *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHealGenerator : MonoBehaviour
{
    public GameObject HealPrefab;
    float span = 6.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(HealPrefab) as GameObject;
            float px = Random.Range(-3.7f, 0);
            go.transform.position = new Vector3(10, px, 0);
        }
    }
}
