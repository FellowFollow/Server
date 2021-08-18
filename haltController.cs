using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haltController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.2f, 0, 0);
        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("coll");
            Destroy(gameObject);
        }
    }
    */
}
