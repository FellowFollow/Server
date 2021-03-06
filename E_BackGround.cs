/*****************************************************************
* @file         E_BackGround.cs                                  *
* @details      설정한 speed만큼 빠르게 배경을 스크롤한다.       *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_BackGround : MonoBehaviour
{
    private MeshRenderer render;
    private float offset;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
