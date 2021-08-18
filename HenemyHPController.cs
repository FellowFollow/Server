using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class HenemyHPController : MonoBehaviour
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
        this.game = GameObject.Find("HardModeDirector");
        this.e_maxHP = this.game.GetComponent<HardDirector>().e_maxHP;

        this.e_HPBar.value = (float)e_curHP / (float)e_maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.e_curHP = this.game.GetComponent<HardDirector>().e_currentHP;
        HandleEHP();
        if (this.e_HPBar.value <= 0)
        {
            SaveScore();
            SceneManager.LoadScene("ClearScene");
        }
    }
    private void HandleEHP()
    {
        this.e_HPBar.value = (float)e_curHP / (float)e_maxHP;
    }

    public void SaveScore()
    {
        currentCoin = this.game.GetComponent<HardDirector>().coin;

        var request = new AddUserVirtualCurrencyRequest() { VirtualCurrency = "GD", Amount = currentCoin };
        PlayFabClientAPI.AddUserVirtualCurrency(request, (result) => { Debug.Log("��� ���� ����"); },
                                                         (error) => { Debug.Log("��� ���� ����"); });

        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            (result) =>
            {
                foreach (var eachStat in result.Statistics)
                    savedScore = eachStat.Value;

                Debug.Log("���� ��� �ҷ����� ����");
            },
            (error) => { Debug.Log("���� ��� �ҷ����� ����"); });

        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate { StatisticName = "Highscore", Value = currentCoin + savedScore}
            }
        },
        (result) => { Debug.Log("���� ���� �Ϸ�"); },
        (error) => { Debug.Log("���� ���� ����"); });
    }

}
