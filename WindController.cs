using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("EasyModeDirector");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.15f, 0, 0);
        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }

    }

    public void UseDestroyItem()
    {
        Destroy(GameObject.Find("windPrefab(Clone)"));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            game.GetComponent<EasyDirector>().DecreaseHp();
            Destroy(gameObject);
        }
    }
}
