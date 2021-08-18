using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    float span = 1.0f;
    float delta = 0;
    float count = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.count++; // 임시로 deltaTime 역할
            this.delta = 0;
            GameObject go = Instantiate(coinPrefab) as GameObject;
            int px = Random.Range(-4, 3);
            go.transform.position = new Vector3(10, px, 0);
        }
    }
}
