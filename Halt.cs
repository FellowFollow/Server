using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halt : MonoBehaviour
{
    GameObject wind;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.wind = GameObject.Find("windGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            SoundManager.instance.SFXPlay("UseItem", clip);
            wind.GetComponent<windGenerator>().windPrefab.gameObject.GetComponent<WindController>().UseDestroyItem();
            Destroy(this.gameObject);
        }
    }
}
