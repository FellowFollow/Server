using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : MonoBehaviour
{
    GameObject game;

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
            game.GetComponent<NormalDirector>().AttackEnemy();
            Destroy(this.gameObject);
        }
    }
}
