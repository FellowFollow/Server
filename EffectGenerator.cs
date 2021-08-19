/***************************************************************************
* @file         EffectGenerator.cs                                         *
* @details      공격 이펙트 프리팹을 게임 오브젝트로 생성시키는 스크립트.  *
*                                                                          *
* ⓒ made by FellowFollow                                                  *
***************************************************************************/

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
