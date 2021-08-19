/*****************************************************************
* @file         Slot.cs                                          *
* @details      각 슬롯의 순서키(1, 2, 3)를 파싱해               *
*               해당 슬롯이 비어있는지 설정                      *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Inventory inventory;
    public int num;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        num = int.Parse(gameObject.name.Substring(gameObject.name.IndexOf("_") + 1));
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.slots[num].isEmpty = true;
        }
    }
}
