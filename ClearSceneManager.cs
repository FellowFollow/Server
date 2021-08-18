/*********************************************************************************************

* @file ClearSceneManager.cs

* @details  ClearScene���� �����ִ� ��������� �ش� ���¸� �˷��ִ� �ؽ�Ʈ�� �ٷ�� �ҽ�����

* �� made by FellowFollow
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
        Invoke("goBackToLobby", 3.0f);//���� �޽��� Ȯ���� ���� 3�� �� �κ�� �̵�.
    }

    public void GetLeaderboard()
    {
        //�������� �ҷ����� ���� request
        var request = new GetLeaderboardRequest
        {
            StartPosition = 0,
            StatisticName = "Highscore",
            MaxResultsCount = 4,
            ProfileConstraints = new PlayerProfileViewConstraints()
            { ShowLocations = true, ShowDisplayName = true }
        };

        //�������� request ��� ó���κ�
        PlayFabClientAPI.GetLeaderboard(request, (result) =>
        {
            for (int i = 1; i <= PhotonNetwork.CurrentRoom.PlayerCount; i++)
            {
                var curBoard = result.Leaderboard[i];
                LeaderboardText.text += i + "�� : " + curBoard.Profile.Locations[0].CountryCode.Value + "  " + 
                                                            curBoard.DisplayName + " : " + curBoard.StatValue + "\n";

            }
        },
        (error) => print("�������� �ҷ����� ����"));

        //�÷��̾� ������ ����� Highscore �ʱ�ȭ�� request
        var request2 = new UpdatePlayerStatisticsRequest();
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "Highscore", Value = 0}
            }
        },
       (result) => { StateText.text = "���� �ʱ�ȭ �Ϸ�"; Debug.Log("���� �ʱ�ȭ �Ϸ�"); },
       (error) => { StateText.text = "���� �ʱ�ȭ ����"; Debug.Log("���� �ʱ�ȭ ����"); });

        //�÷��̾� ������ ����� ���� ���� Ȯ�ο� request
        var request3 = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "GD", Amount = 0 };
        PlayFabClientAPI.AddUserVirtualCurrency(request3, (result) => StateText.text = "���� ����"+ result.Balance,
                                                         (error) => StateText.text = "��� ��� ����");

        StateText.text = "��� �� �κ�� �ǵ��ư��ϴ�.";
    }

    public void goBackToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
