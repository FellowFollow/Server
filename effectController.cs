/***************************************************************************
* @file         effectController.cs                                        *
* @details      �������� ���� �� ������ ���� ����Ʈ�� �����ϴ� ��ũ��Ʈ.   *
*               ������ �ӵ��� translate��Ű��                              *
*               ��ǥ���� Boss�� �ε����� Destroy ��Ų��.                   *
*                                                                          *
* �� made by FellowFollow                                                  *
***************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0.15f, 0, 0);
        if (transform.position.x > 9.5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
