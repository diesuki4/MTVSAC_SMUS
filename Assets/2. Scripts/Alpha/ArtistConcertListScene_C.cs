using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArtistConcertListScene_C : MonoBehaviour
{
    InputField id;
    InputField passwd;
    public Transform concertParent;
    public GameObject concertButton;

    void Start()
    {
        id = transform.Find("Option/Image (3)/ID InputField").GetComponent<InputField>();
        passwd = transform.Find("Option/Image (3)/PW InputField").GetComponent<InputField>();

        id.text = AccountManager.id;
        passwd.text = "";

        PlayerPrefs.DeleteKey("concert_id");

        LoadMyConcerts();
    }

    void LoadMyConcerts()
    {
        List<ConcertInfo> myConcerts = ConcertManager.GetConcertsWithId(AccountManager.id, false);

        foreach (ConcertInfo info in myConcerts)
        {
            int concert_id = info.concert_id;

            GameObject concertBtn = Instantiate(concertButton, Vector3.zero, Quaternion.identity, concertParent);

            concertBtn.GetComponent<ConcertButton>().Initialize(info);
            concertBtn.GetComponent<Image>().overrideSprite = MediaProcessor.ToSprite(ConcertManager.GetConcertData(concert_id).thumbnail);
        }
    }

    public void OnClickModify()
    {
        if (AccountManager.Update(passwd.text, AccountManager.genre))
        {
            Debug.Log("정보 수정 성공");
            transform.Find("Option").gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("정보 수정 실패");
        }
    }

    public void OnClickLogout()
    {
        AccountManager.Logout();
        
        Debug.Log("로그아웃");

        SceneManager.LoadScene("ShowLoginScene_C");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
