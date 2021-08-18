/***************************************************************************************************

* @file FailScoreManager.cs

* @details  FailScene에서 이뤄지는 변수 초기화 과정과 해당 상태를 알려주는 텍스트를 다루는 소스파일

* ⓒ made by FellowFollow
****************************************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class FailScoreManager : MonoBehaviour
{
    public Text FailSaveText; //상태 저장용 텍스트

    GameObject game;

    [SerializeField]
    public static int coin;
    int savedScore;


    void Start()
    {
        Debug.Log(coin);
        SaveFailedScore();
        Invoke("backToLobby", 3.0f);//현재 상태 확인 후 3초 후 로비로 자동 이동
    }

    public void SaveFailedScore()
    {
        //이전 스테이지에서 모은 코인을 플레이어 계정에 저장하기 위한 request
        var request = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "GD", Amount = coin };
        PlayFabClientAPI.AddUserVirtualCurrency(request, (result) => { FailSaveText.text = "골드 저장 성공"; Debug.Log("골드 저장 성공"); },
                                                         (error) => { FailSaveText.text = "골드 저장 실패"; Debug.Log("골드 저장 실패"); });

        //이전 스테이지까지 모은 코인을 저장하는 변수 호출용 request
        var request2 = new GetPlayerStatisticsRequest();
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    savedScore = eachStat.Value;
                FailSaveText.text = "기존 기록 불러오기 성공";
                Debug.Log("기존 기록 불러오기 성공");
            },
            (error) => { FailSaveText.text = "기존 기록 불러오기 실패";  Debug.Log("기존 기록 불러오기 실패"); });

        //이전 스테이지까지 모은 코인을 저장하는 변수 초기화용 request
        var request3 = new UpdatePlayerStatisticsRequest();
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "Highscore", Value = 0}
            }
        },
        (result) => { FailSaveText.text = "점수 초기화 완료"; Debug.Log("점수 초기화 완료"); },
        (error) => { FailSaveText.text = "점수 초기화 실패"; Debug.Log("점수 초기화 실패"); });

        FailSaveText.text = "잠시 후 로비로 이동합니다.";
    }
    public void backToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}
