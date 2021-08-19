/*****************************************************************
* @file         reflectionController.cs                          *
* @details      공격 아이템이 일정 속도로 날아가게 하고          *
*               맵 밖으로 나가면 Destroy시킨다.                  *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectionController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.2f, 0, 0);
        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }
    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("coll");
            Destroy(gameObject);
        }
    }
    */
}
