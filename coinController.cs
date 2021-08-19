/*****************************************************************
* @file         coinController.cs                                *
* @details      coin이 일정 속도로 날아가게 하고                 *
*               맵 밖으로 나가면 Destroy시킨다.                  *
*               Player와 충돌하면 효과음과 함께 점수를 올린다.   *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    GameObject game;
    public AudioClip clip;

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.instance.SFXPlay("coin", clip);
            this.game.GetComponent<EasyDirector>().ScorePoint();
            Destroy(gameObject);
        }
    }
}
