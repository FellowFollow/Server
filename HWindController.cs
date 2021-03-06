/***************************************************************************************
* @file     HWindController.cs                                                         *
* @details  HardScene의 보스가 공격할 때 나오는 회오리의 속도와 충돌을 다루는 소스파일 *
*                                                                                      *
* ⓒ made by FellowFollow                                                              *
***************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HWindController : MonoBehaviour
{
    GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("HardModeDirector");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.38f, 0, 0);
        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }

    }

    public void UseDestroyItem()
    {
        Destroy(GameObject.Find("HwindPrefab(Clone)"));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            game.GetComponent<HardDirector>().DecreaseHp();
            Destroy(gameObject);
        }
    }
}
