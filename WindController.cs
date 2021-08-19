/***************************************************************************
* @file         WindController.cs                                          *
* @details      플레이어 공격 아이템이 일정 속도로 날아가게 하고           *
*               맵 밖으로 나가거나 Player와 충돌하면 Destroy 시킴.         *
*               UseDestroyItem() 함수: 맵 내에서 생성되는 장애물을 파괴    *
*                                                                          *
* ⓒ made by FellowFollow                                                  *
***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("EasyModeDirector");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.15f, 0, 0);
        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }

    }

    public void UseDestroyItem()
    {
        Destroy(GameObject.Find("windPrefab(Clone)"));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            game.GetComponent<EasyDirector>().DecreaseHp();
            Destroy(gameObject);
        }
    }
}
