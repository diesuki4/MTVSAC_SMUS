using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowLoginScene_C : MonoBehaviour
{
    Dropdown dropdown;
    InputField id;
    InputField passwd;

    LogInScript ls;
    void Start()
    {
        PlayerPrefs.DeleteKey("Created");

        //dropdown = transform.Find("VerDropdown").GetComponent<Dropdown>();
        id = GameObject.Find("UserID").GetComponent<InputField>();
        passwd = GameObject.Find("UserPW").GetComponent<InputField>();

        // 아티스트 관객 구분
        ls = this.GetComponent<LogInScript>();
    }

    public void OnClickLogin()
    {
        if (AccountManager.Login(id.text, passwd.text) == false)
        {
            Debug.Log("로그인 실패");
            id.text = "";
            passwd.text = "";
            return;
        }
        
        Debug.Log("로그인 성공");

        // 관객
        if (ls.amIArtist == false)
            SceneManager.LoadScene("ScrollScene");
        // 아티스트
        else if (ls.amIArtist == true)
            SceneManager.LoadScene("ArtistConcertListScene_C");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
