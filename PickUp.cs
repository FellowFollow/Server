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
