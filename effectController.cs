/***************************************************************************
* @file         effectController.cs                                        *
* @details      아이템을 먹을 때 나오는 공격 이펙트를 조절하는 스크립트.   *
*               일정한 속도로 translate시키고                              *
*               목표물인 Boss와 부딪히면 Destroy 시킨다.                   *
*                                                                          *
* ⓒ made by FellowFollow                                                  *
***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0.15f, 0, 0);
        if (transform.position.x > 9.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
