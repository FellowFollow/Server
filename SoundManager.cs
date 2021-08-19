/*****************************************************************
* @file         SoundManager.cs                                  *
* @details      맵에서 게임 효과음 및 bgm을 재생하는 역할        *
*               public void형으로 선언한 SFXPlay함수를           *
*               다른 스크립트에서 호출하는 방식으로 사용.        *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    //public AudioSource bgSound;
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /*
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for (int i = 0; i < bglist.Length; i++)
        {
            if (arg0.name == bglist[i].name)
                BGMplay(bglist[i]);
        }
    }
    */
    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);
    }
}
