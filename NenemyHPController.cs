/*****************************************************************
* @file         NenemyHPcontroller.cs                            *
* @details      �븻 ����� ����(��)�� HP�� �����ϴ� ��ũ��Ʈ.   *
*               ���� HP�� ���¸� ǥ���ϴ� Slider�� ���� �����ϰ� *
*               ��ָ�� ������ ��ȯ �� ���� ������ �Ѵ�.        *
*                                                                *
* �� made by FellowFollow                                        *
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
