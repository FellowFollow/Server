/**********************************************************************
* @file         PickUp.cs                                             *
* @details      아이템들과 연결하여 획득 가능 상태가 되게 함          *
*               이 스크립트를 붙인 게임 오브젝트가 player와 충돌하면  *
*               효과음과 함께 앞에서부터 해당 아이템이 들어간         *
*               슬롯 이미지로 변경되며 해당 슬롯이 채워짐.            *
*                                                                     *
* ⓒ made by FellowFollow                                             *
**********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject slotItem;
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Inventory inven = other.GetComponent<Inventory>();
            for (int i = 0; i < inven.slots.Count; i++)
            {
                if (inven.slots[i].isEmpty)
                {
                    SoundManager.instance.SFXPlay("PickUpItem", clip);
                    Instantiate(slotItem, inven.slots[i].slotObj.transform, false);
                    inven.slots[i].isEmpty = false;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
