using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class FailScoreManager : MonoBehaviour
{
    public Text FailSaveText;

    GameObject game;

    [SerializeField]
    public static int coin;
    int savedScore;


    void Start()
    {
        Debug.Log(coin);
        SaveFailedScore();
        Invoke("backToLobby", 3.0f);
    }

    public void SaveFailedScore()
    { 
        var request = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "GD", Amount = coin };
        PlayFabClientAPI.AddUserVirtualCurrency(request, (result) => { FailSaveText.text = "골드 저장 성공"; Debug.Log("골드 저장 성공"); },
                                                         (error) => { FailSaveText.text = "골드 저장 실패"; Debug.Log("골드 저장 실패"); });

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
