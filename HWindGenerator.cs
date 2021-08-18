/**************************************************************************************

* @file HWindGenerator.cs

* @details  HardScene�� ������ ������ �� ������ ȸ������ ������ �󵵸� �ٷ�� �ҽ�����

* �� made by FellowFollow
***************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HWindGenerator : MonoBehaviour
{
    public GameObject windPrefab;
    public AudioClip clip;
    float span = 4.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(windPrefab) as GameObject;
            SoundManager.instance.SFXPlay("wind", clip);
            go.transform.position = new Vector3(10, -3.6f, 0);
        }
    }
}
