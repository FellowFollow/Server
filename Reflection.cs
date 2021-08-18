using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    GameObject effect;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.effect = GameObject.Find("EffectGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            effect.GetComponent<EffectGenerator>().Attack();
            SoundManager.instance.SFXPlay("attack", clip);
            Destroy(this.gameObject);
        }
    }
}
