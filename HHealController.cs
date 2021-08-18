/******************************************************************
* @file HHealControlloer.cs                                       *
* @details  HardScene의 치유 아이템의 이동를 다루는 소스파일      *
*                                                                 *
* ⓒ made by FellowFollow                                         *
*******************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHealController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-0.25f, 0, 0);
        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }
    }
}
