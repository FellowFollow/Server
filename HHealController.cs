using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHealController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-0.25f, 0, 0);
        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }
    }
}
