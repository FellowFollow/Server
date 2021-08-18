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
