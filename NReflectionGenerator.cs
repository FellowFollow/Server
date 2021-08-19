/********************************************************************
* @file         NReflectionGenerator.cs                             *
* @details      ��ָ�忡�� ���� �ð����� ���� �������� �����Ѵ�.  *
*                                                                   *
* �� made by FellowFollow                                           *
********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NReflectionGenerator : MonoBehaviour
{
    public GameObject reflectionPrefab;
    float span = 6.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(reflectionPrefab) as GameObject;
            float px = Random.Range(-3.7f, 0);
            go.transform.position = new Vector3(10, px, 0);
        }
    }
}
