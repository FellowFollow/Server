using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;
using Photon.Pun;
using Photon.Realtime;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public InputField PW_Input;
    public InputField Email_Input;
    public InputField UserName_Input;

    public Text Status;

    public GameObject LoginPanel;
    public GameObject NamePanel;

    private string password;
    private string email;
    private string userName;

    
    void Start()
    {
        PlayFabSettings.TitleId = "E212F";
    }

    public void PW_value_Changed()
    {
        password = PW_Input.text.ToString();
    }

    public void Email_value_Changed()
    {
        email = Email_Input.text.ToString();
    }

    public void Name_value_Changed()
    {
        userName = UserName_Input.text.ToString();
    }

    ///<summary>
    ///로그인 기능
    ///<summary>
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest {
           Email = email,
           Password = password
        };
        
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("로그인 성공");

        var request = new GetAccountInfoRequest { Email = email };
        PlayFabClientAPI.GetAccountInfo(request, GetAccountSuccess, GetAccountFailure);

    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("로그인 실패");
        Debug.LogWarning(error.GenerateErrorReport());
        Status.text ="로그인에 실패하였습니다. 다시 입력해주세요";
    }

    private void GetAccountSuccess(GetAccountInfoResult result)
    {
        Debug.Log("Account를 정상적으로 받아옴");

        string name = result.AccountInfo.TitleInfo.DisplayName;

        if (name == null) {
            LoginPanel.SetActive(false);
            NamePanel.SetActive(true);
        }

        else
        {
            PhotonNetwork.LocalPlayer.NickName = name;
            
            PlayerPrefs.SetString("Nickname", name);
            Status.text = name + "님 환영합니다!";
        }

    }

    private void GetAccountFailure(PlayFabError obj)
    {
        Debug.Log("Account를 받지 못함");
        Status.text = "Account를 받지 못했습니다.";
    }

    private void OnPasswordError(PlayFabError error) 
    {
        Debug.LogWarning("비밀번호 오류");
        Debug.LogWarning(error.GenerateErrorReport());
        Status.text = "비밀번호를 다시 입력해주세요";
    }

    public void ResetPassword() {
        var request = new SendAccountRecoveryEmailRequest {
            Email = email,
            TitleId = "E212F"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnPasswordError);
    }

    private void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        Status.text = "비밀번호 재설정을 위한 이메일이 발송되었습니다";
    }

    ///<summary>
    ///회원가입 기능
    ///<summary>
    
    public void Register()
    {
       var request = new RegisterPlayFabUserRequest {
           Email = email,
           Password = password,
           RequireBothUsernameAndEmail = false
       };
       PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("가입 성공");
        Status.text = "가입 성공";
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogWarning("가입 실패");
        Debug.LogWarning(error.GenerateErrorReport());
        Status.text = "가입에 실패하였습니다. 다시 입력해주세요";
    }

    ///<summary>
    ///닉네임 등록
    ///<summary>
    public void Name()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = UserName_Input.text
        };
        
        PhotonNetwork.NickName = request.DisplayName;
        Debug.Log (PhotonNetwork.NickName + ": sync complete Photon NickName");
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, DisplayNameUpdateSuccess, DisplayNameUpdateFailure);
    }
    
    private void DisplayNameUpdateSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("닉네임 설정 성공");
        string name = result.DisplayName;

        LoginPanel.SetActive(true);
        NamePanel.SetActive(false);
        
        PhotonNetwork.NickName = result.DisplayName;
     //   PhotonNetwork.LocalPlayer.NickName = result.DisplayName;
        Status.text = "Set name: " + name;
    }

    private void DisplayNameUpdateFailure(PlayFabError error)
    {
            Debug.LogWarning("닉네임 생성 실패");
            Debug.LogWarning(error.GenerateErrorReport());
    }


    public void LobbyScene() {
        SceneManager.LoadScene("Lobby");
    }

}
