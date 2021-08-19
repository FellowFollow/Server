/*****************************************************************
* @file         NCoinController.cs                               *
* @details      �븻 ����� coinController
*               coin�� ���� �ӵ��� ���ư��� �ϰ�                 *
*               �� ������ ������ Destroy��Ų��.                  *
*               Player�� �浹�ϸ� ȿ������ �Բ� ������ �ø���.   *
*                                                                *
* �� made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCoinController : MonoBehaviour
{
    GameObject game;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("NormalModeDirector");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.26f, 0, 0);

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
            this.game.GetComponent<NormalDirector>().ScorePoint();
            Destroy(gameObject);
        }
    }
}
