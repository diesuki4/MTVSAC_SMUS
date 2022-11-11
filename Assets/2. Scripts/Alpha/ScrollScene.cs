using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollScene : MonoBehaviour
{
    Dropdown dropdown;
    InputField passwd;

    void Start()
    {
        dropdown = transform.Find("Option/BackGroundImage/Tag Dropdown").GetComponent<Dropdown>();
        passwd = transform.Find("Option/BackGroundImage/PW InputField").GetComponent<InputField>();

        dropdown.value = dropdown.options.FindIndex(option => option.text == AccountManager.genre);
        passwd.text = AccountManager.passwd;
    }

    public void OnClickModify()
    {
        if (AccountManager.Update(passwd.text, dropdown.options[dropdown.value].text))
            Debug.Log("정보 수정 성공");
        else
            Debug.Log("정보 수정 실패");
    }

    public void OnClickLogout()
    {
        AccountManager.Logout();
        
        Debug.Log("로그아웃");

        SceneManager.LoadScene("ShowLoginScene_C 1");
    }
}
