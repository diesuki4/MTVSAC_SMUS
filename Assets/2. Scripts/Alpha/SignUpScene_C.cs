using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignUpScene_C : MonoBehaviour
{
    Dropdown dropdown;
    InputField id;
    InputField passwd;

    void Start()
    {
        dropdown = transform.Find("Tag Dropdown").GetComponent<Dropdown>();
        id = transform.Find("ID InputField").GetComponent<InputField>();
        passwd = transform.Find("PW InputField").GetComponent<InputField>();
    }

    public void OnClickSignUp()
    {
        if (AccountManager.SignUp(id.text, passwd.text, dropdown.options[dropdown.value].text) == false)
        {
            Debug.Log("회원가입 실패");
            id.text = "";
            passwd.text = "";
            return;
        }
        
        Debug.Log("회원가입 성공");

        SceneManager.LoadScene("ShowLoginScene_C 1");
    }

    public void OnClickLogin()
    {
        SceneManager.LoadScene("ShowLoginScene_C 1");  
    }
}
