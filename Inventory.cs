/**************************************************************************
* @file         Inventory.cs                                              *
* @details      플레이어 오브젝트에 붙여 인벤토리 역할을 하는 스크립트.   *
*               슬롯 데이터를 생성 및 추가한다.                           *
*                                                                         *
* ⓒ made by FellowFollow                                                 *
**************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<SlotData> slots = new List<SlotData>();
    private int maxSlot = 3;
    public GameObject slotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject slotPanel = GameObject.Find("Panel");

        for (int i = 0; i < maxSlot; i++)
        {
            GameObject go = Instantiate(slotPrefab, slotPanel.transform, false);
            go.name = "Slot_" + i;
            //SlotData slot = new SlotData();
            SlotData slot = this.gameObject.AddComponent<SlotData>();
            slot.isEmpty = true;
            slot.slotObj = go;
            slots.Add(slot);
        }
    }
}
