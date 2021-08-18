using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHeal : MonoBehaviour
{
    GameObject game;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("HardModeDirector");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.inputString == (transform.parent.GetComponent<Slot>().num + 1).ToString())
        {
            SoundManager.instance.SFXPlay("UseItem", clip);
            game.GetComponent<HardDirector>().HealHP();
            Destroy(this.gameObject);
        }
    }
}
