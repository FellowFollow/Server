/*************************************************************************
* @file         NHeal.cs                                                 *
* @details      ��� ����� ü�� ȸ�� ������ ��� ȿ���� ���� ��ũ��Ʈ.  *
*               Ű���� 1~3 �� �ش��ϴ� ��ư�� ������                     *
*               ������ ���� ���ÿ� ȿ������ ����ǰ�                   *
*               �÷��̾��� ü���� ȸ����Ű�� HealHP()�Լ��� ȣ��.        *
*                                                                        *
* �� made by FellowFollow                                                *
*************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHeal : MonoBehaviour
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
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            SoundManager.instance.SFXPlay("UseItem", clip);
            game.GetComponent<NormalDirector>().HealHP();
            Destroy(this.gameObject);
        }
    }
}
