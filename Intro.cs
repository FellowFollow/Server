using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("Login");
    }

    public void ClickExplain()
    {
        SceneManager.LoadScene("ExplainScene");
    }
}
