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
        PlayFabClientAPI.AddUserVirtualCurrency(request, (result) => { FailSaveText.text = "��� ���� ����"; Debug.Log("��� ���� ����"); },
                                                         (error) => { FailSaveText.text = "��� ���� ����"; Debug.Log("��� ���� ����"); });

        var request2 = new GetPlayerStatisticsRequest();
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    savedScore = eachStat.Value;
                FailSaveText.text = "���� ��� �ҷ����� ����";
                Debug.Log("���� ��� �ҷ����� ����");
            },
            (error) => { FailSaveText.text = "���� ��� �ҷ����� ����";  Debug.Log("���� ��� �ҷ����� ����"); });


        var request3 = new UpdatePlayerStatisticsRequest();
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "Highscore", Value = 0}
            }
        },
        (result) => { FailSaveText.text = "���� �ʱ�ȭ �Ϸ�"; Debug.Log("���� �ʱ�ȭ �Ϸ�"); },
        (error) => { FailSaveText.text = "���� �ʱ�ȭ ����"; Debug.Log("���� �ʱ�ȭ ����"); });

        FailSaveText.text = "��� �� �κ�� �̵��մϴ�.";
    }
    public void backToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

}
