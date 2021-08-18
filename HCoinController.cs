using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class HCoinController : MonoBehaviour
{
    GameObject game;
    public AudioClip clip;

    public int currentCoin;
    public int savedScore;

    Text ScoreSaveText;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("HardModeDirector");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.3f, 0, 0);

        if (transform.position.x < -9.5f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.instance.SFXPlay("coin", clip);
            this.game.GetComponent<HardDirector>().ScorePoint();
            Destroy(gameObject);
        }
    }
}
