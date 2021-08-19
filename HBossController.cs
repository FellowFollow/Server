/******************************************************************
* @file     HBossController.cs                                    *
* @details  HardScene의 보스의 피격 효과를 다루는 소스파일        *
*                                                                 *
* ⓒ made by FellowFollow                                         *
******************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBossController : MonoBehaviour
{
    SpriteRenderer spriteRender;
    GameObject game;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("HardModeDirector");
        this.spriteRender = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            Ondamaged();
        }
    }

    void Ondamaged()
    {
        SoundManager.instance.SFXPlay("Attack", clip);
        spriteRender.color = new Color(1, 1, 1, 0.4f);
        game.GetComponent<HardDirector>().AttackEnemy();
        Invoke("OffDamaged", 0.5f);
    }

    void OffDamaged()
    {
        spriteRender.color = new Color(1, 1, 1, 1);
    }
}
