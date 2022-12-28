using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class UserInfo
{
    public string id;
    public string pwd;
    public string nickname;

    public int score;
}

public class DataBaseServer : MonoBehaviour
{
    [SerializeField] private string severURL = null;
    [SerializeField] private int port = 0;
    [SerializeField] private string sceneName = null;

    [SerializeField] private TMP_InputField inputID  = null;
    [SerializeField] private TMP_InputField inputPWD = null;

    [SerializeField] private GameObject firstNameBox = null;
    [SerializeField] private TMP_InputField inputNicName = null;


    private List<UserInfo> userlist = null;
    private UserInfo loginUser = null;
    private bool isProcessing = false;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

 

    //login CompareData
    public void OnClick_LoginConfirm()
    {
        if (isProcessing) return;

        isProcessing = true;

        UserInfo userInfo = new UserInfo();
        userInfo.id = inputID.text;
        userInfo.pwd = inputPWD.text;

        string jsonData = JsonUtility.ToJson(userInfo);

        StartCoroutine(ProcessLogin(jsonData));
    }

    private IEnumerator ProcessLogin(string jsonData)
    {
        string targetURL = severURL + ":" + port + "/Userlogin";

        using (UnityWebRequest request = UnityWebRequest.Post(targetURL, jsonData))
        {

            byte[] jsonTOSend = new System.Text.UTF8Encoding().GetBytes(jsonData);


            request.uploadHandler = new UploadHandlerRaw(jsonTOSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                UnityEngine.Debug.Log(request.error);
            }
            else
            {
                loginUser = new UserInfo();
                loginUser = JsonConvert.DeserializeObject<UserInfo>(request.downloadHandler.text);

                Debug.Log(loginUser.id);

                if(loginUser==null)
                {
                    Debug.Log("아이디 잘못 치거나 없음");
                    isProcessing = false;
                    yield break;
                }

                if (loginUser.nickname==""|| loginUser.nickname == null)
                {
                    Debug.Log("닉네임이 없습니다.");
                    firstNameBox.SetActive(true);
                }
                else
                {
                    Debug.Log("닉네임이 존재합니다.");
                    UnityEngine.Debug.Log(request.downloadHandler.text);
                    Debug.Log(loginUser.score.ToString());
                    SceneManager.LoadScene(sceneName);
                }

            }

            isProcessing = false;
        }
    }


    //Save NickName
    public void OnClick_NickNameConfirm()
    {
        if (isProcessing) return;

        isProcessing = true;

        UserInfo userInfo = new UserInfo();
        userInfo.nickname = inputNicName.text;

        string jsonData = JsonUtility.ToJson(userInfo);

        StartCoroutine(ProcessSaveNickName(jsonData));
    }

    private IEnumerator ProcessSaveNickName(string jsonData)
    {
        string targetURL = severURL + ":" + port + "/saveusernickname";

        using (UnityWebRequest request = UnityWebRequest.Post(targetURL, jsonData))
        {

            byte[] jsonTOSend = new System.Text.UTF8Encoding().GetBytes(jsonData);

            Debug.Log(System.Text.Encoding.Default.GetString(jsonTOSend));

            request.uploadHandler = new UploadHandlerRaw(jsonTOSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                UnityEngine.Debug.Log(request.error);
            }
            else
            {
                Debug.Log("데이터 저장");

                UnityEngine.Debug.Log(request.downloadHandler.text);
                SceneManager.LoadScene(sceneName);
            }

            isProcessing = false;
        }
    }

    //FindPicture Save Score
    public void FindPictureSaveScore(int score)
    {
        if (isProcessing) return;

        if (loginUser.score >= score) return;

        isProcessing = true;
       
        loginUser.score = score;

        string jsonData = JsonUtility.ToJson(loginUser);
        Debug.Log(jsonData);

        StartCoroutine(ProcessSaveScore(jsonData));
    }

    private IEnumerator ProcessSaveScore(string jsonData)
    {
        string targetURL = severURL + ":" + port + "/saveuserscore";

        using (UnityWebRequest request = UnityWebRequest.Post(targetURL, jsonData))
        {

            byte[] jsonTOSend = new System.Text.UTF8Encoding().GetBytes(jsonData);

            Debug.Log(System.Text.Encoding.Default.GetString(jsonTOSend));

            request.uploadHandler = new UploadHandlerRaw(jsonTOSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                UnityEngine.Debug.Log(request.error);
            }
            else
            {
                UnityEngine.Debug.Log(request.downloadHandler.text);
            }

            isProcessing = false;
        }
    }


}


