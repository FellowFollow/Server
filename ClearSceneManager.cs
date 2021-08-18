/*********************************************************************************************

* @file ClearSceneManager.cs

* @details  ClearScene에서 보여주는 리더보드와 해당 상태를 알려주는 텍스트를 다루는 소스파일

* ⓒ made by FellowFollow
**********************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;


public class ClearSceneManager : MonoBehaviour
{
    public Text LeaderboardText;
    public Text StateText;

    void Start()
    {
        GetLeaderboard();
        Invoke("goBackToLobby", 3.0f);//상태 메시지 확인을 위해 3초 후 로비로 이동.
    }

    public void GetLeaderboard()
    {
        //리더보드 불러오기 위한 request
        var request = new GetLeaderboardRequest
        {
            StartPosition = 0,
            StatisticName = "Highscore",
            MaxResultsCount = 4,
            ProfileConstraints = new PlayerProfileViewConstraints()
            { ShowLocations = true, ShowDisplayName = true }
        };

        //리더보드 request 결과 처리부분
        PlayFabClientAPI.GetLeaderboard(request, (result) =>
        {
            for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
            {
                var curBoard = result.Leaderboard[i];
                LeaderboardText.text += i + "위 : " + curBoard.Profile.Locations[0].CountryCode.Value + "  " + 
                                                            curBoard.DisplayName + " : " + curBoard.StatValue + "\n";

            }
        },
        (error) => print("리더보드 불러오기 실패"));

        //플레이어 계정에 저장된 Highscore 초기화용 request
        var request2 = new UpdatePlayerStatisticsRequest();
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "Highscore", Value = 0}
            }
        },
       (result) => { StateText.text = "점수 초기화 완료"; Debug.Log("점수 초기화 완료"); },
       (error) => { StateText.text = "점수 초기화 실패"; Debug.Log("점수 초기화 실패"); });

        //플레이어 계정에 저장된 현재 코인 확인용 request
        var request3 = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "GD", Amount = 0 };
        PlayFabClientAPI.AddUserVirtualCurrency(request3, (result) => StateText.text = "현재 코인"+ result.Balance,
                                                         (error) => StateText.text = "골드 얻기 실패");

        StateText.text = "잠시 후 로비로 되돌아갑니다.";
    }

    public void goBackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
