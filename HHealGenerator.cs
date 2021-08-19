/******************************************************************
* @file     HHealGenerator.cs                                     *
* @details  HardScene의 치유 아이템의 생성 속도를 다루는 소스파일 *
*                                                                 *
* ⓒ made by FellowFollow                                         *
******************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHealGenerator : MonoBehaviour
{
    public GameObject HealPrefab;
    float span = 19.0f;
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
