using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListOption : MonoBehaviour
{
    public GameObject option;

    // Start is called before the first frame update
    void Start()
    {
        option.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 옵션창 켜짐
    public void OnClickOptionButton()
    {
        option.SetActive(true);
    }

    // 옵션창 꺼짐
    public void OnClickCloseButton()
    {
        option.SetActive(false);
    }

    // 로그아웃 버튼 누르면 로그인 창으로 돌아감
    public void OnClickLogoutButton()
    {
        SceneManager.LoadScene("LoginScene_C");
    }
}
