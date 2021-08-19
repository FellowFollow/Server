/**************************************************************************
* @file         Inventory.cs                                              *
* @details      �÷��̾� ������Ʈ�� �ٿ� �κ��丮 ������ �ϴ� ��ũ��Ʈ.   *
*               ���� �����͸� ���� �� �߰��Ѵ�.                           *
*                                                                         *
* �� made by FellowFollow                                                 *
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
