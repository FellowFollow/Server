using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGenerator : MonoBehaviour
{
    public GameObject attackPrefab;

    public void Attack()
    {
        GameObject go = Instantiate(attackPrefab) as GameObject;
        go.transform.position = new Vector3(-10, -1.6f, 0);
    }
}
