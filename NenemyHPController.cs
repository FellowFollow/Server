/*****************************************************************
* @file         NenemyHPcontroller.cs                            *
* @details      노말 모드의 보스(적)의 HP를 관리하는 스크립트.   *
*               보스 HP의 상태를 표시하는 Slider의 값을 조절하고 *
*               노멀모드 씬으로 전환 및 점수 저장을 한다.        *
*                                                                *
* ⓒ made by FellowFollow                                        *
*****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class NenemyHPController : MonoBehaviour
{
    GameObject game;

    [SerializeField]
    private Slider e_HPBar;
    float e_maxHP;
    float e_curHP;

    public int currentCoin;
    public int savedScore;
    Text ScoreSaveText;

    // Start is called before the first frame update
    void Start()
    {
        this.game = GameObject.Find("NormalModeDirector");
        this.e_maxHP = this.game.GetComponent<NormalDirector>().e_maxHP;

        this.e_HPBar.value = (float)e_curHP / (float)e_maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.e_curHP = this.game.GetComponent<NormalDirector>().e_currentHP;
        HandleEHP();

        if (this.e_HPBar.value <= 0)
        {
            SaveScore();
            SceneManager.LoadScene("HardMode");
        }
    }
    private void HandleEHP()
    {
        this.e_HPBar.value = (float)e_curHP / (float)e_maxHP;
    }

    public void SaveScore()
    {
        currentCoin = this.game.GetComponent<NormalDirector>().coin;

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
        (result) => { Debug.Log("점수 저장 완료"); },
        (error) => { Debug.Log("점수 저장 실패"); });
    }
}
