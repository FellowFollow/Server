using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class enemyHPcontroller : MonoBehaviour
{
    GameObject game;
    public Text ScoreSaveText;

    [SerializeField]
    private Slider e_HPBar;
    float e_maxHP;
    float e_curHP;
    public int currentCoin;
    public int savedScore;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("EasyModeDirector");
        this.e_maxHP = this.game.GetComponent<EasyDirector>().e_maxHP;

        this.e_HPBar.value = (float)e_curHP / (float)e_maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.e_curHP = this.game.GetComponent<EasyDirector>().e_currentHP;
        HandleEHP();

        if (this.e_HPBar.value <= 0)
        {
            SaveScore();
            SceneManager.LoadScene("NormalMode");
        }
    }
    private void HandleEHP()
    {
        this.e_HPBar.value = (float)e_curHP / (float)e_maxHP;
    }

    public void SaveScore()
    {
        currentCoin = this.game.GetComponent<EasyDirector>().coin;

        var request = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "GD", Amount = currentCoin };
        PlayFabClientAPI.AddUserVirtualCurrency(request, (result) => { Debug.Log("골드 저장 성공"); },
                                                         (error) => { Debug.Log("골드 저장 실패"); });

        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    savedScore = eachStat.Value;
                
                Debug.Log("기존 기록 불러오기 성공");
            },
            (error) => { Debug.Log("기존 기록 불러오기 실패"); });

        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "Highscore", Value = currentCoin + savedScore}
            }
        },
        (result) => {  Debug.Log("점수 저장 완료"); },
        (error) => {  Debug.Log("점수 저장 실패"); });
    }
}
