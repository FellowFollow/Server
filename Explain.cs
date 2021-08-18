/*********************************************************************************************

* @file Explain.cs

* @details  ExplainScene을 다루는 소스파일

* ⓒ made by FellowFollow
**********************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explain : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
