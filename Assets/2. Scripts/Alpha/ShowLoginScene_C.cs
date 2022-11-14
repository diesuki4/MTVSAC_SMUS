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

    void Start()
    {
        PlayerPrefs.DeleteKey("Created");

        dropdown = transform.Find("VerDropdown").GetComponent<Dropdown>();
        id = transform.Find("ID InputField").GetComponent<InputField>();
        passwd = transform.Find("PW InputField").GetComponent<InputField>();
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
        if (dropdown.value == 0)
            SceneManager.LoadScene("ScrollScene");
        // 아티스트
        else if (dropdown.value == 1)
            SceneManager.LoadScene("ArtistConcertListScene_C");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
