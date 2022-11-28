using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SignUpScript : MonoBehaviour
{
    public RectTransform[] sets = new RectTransform[3];
    public InputField[] userInfo = new InputField[2];
    public Text[] profileText = new Text[2];

    int buttonCount = 0;
    List<string> genres = new List<string>();

    InputField id;
    InputField passwd;

    // Start is called before the first frame update
    void Start()
    {
        id = userInfo[0];
        passwd = userInfo[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 아이디, 비밀 번호가 한 글자씩은 입력되어있어야 true
    bool CheckInputField()
    {
        print(userInfo[0].text.Length + ", " + userInfo[1].text.Length);
        if (userInfo[0].text.Length >= 1 && userInfo[1].text.Length >= 1) return true;
        else return false;
    }

    // 버튼을 누르면 색 바꾸기
    public void ClickChangeButtonColor()
    {
        Color c = new Color(1, 225 / 255f, 0);

        // 3개까지만
        if (buttonCount < 3 && EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color == Color.white)
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = c;
            genres.Add(EventSystem.current.currentSelectedGameObject.name);
            buttonCount++;
        }
        else if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color == c)
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.white;
            genres.Remove(EventSystem.current.currentSelectedGameObject.name);
            buttonCount--;
        }

    }

    // 버튼이 3개 눌려있으면 true
    bool CheckButtonCount()
    {
        if (buttonCount == 3)
        {
            return true;
        }
        else return false;
    }

    // 회원가입 -> 장르 선택
    public void ClickSignUpToSelectGenre()
    {

        //if (AccountManager.SignUp(id.text, passwd.text) == false)
        //{
        //    Debug.Log("회원가입 실패");
        //    id.text = "";
        //    passwd.text = "";
        //    return;
        //}
        //else
        //{
        //    Debug.Log("회원가입 성공");
        //    if (CheckInputField())
        //    {
        //        PlayerPrefs.SetString("UserID", userInfo[0].text);
        //        sets[0].DOAnchorPosX(-1700, 0.4f).SetEase(Ease.OutExpo);
        //        sets[1].DOAnchorPosX(0, 0.4f).SetEase(Ease.OutExpo);
        //        sets[2].DOAnchorPosX(1700, 0.4f).SetEase(Ease.OutExpo);
        //    }
        //}

        if (CheckInputField())
        {
            PlayerPrefs.SetString("UserID", userInfo[0].text);
            sets[0].DOAnchorPosX(-1700, 0.4f).SetEase(Ease.OutExpo);
            sets[1].DOAnchorPosX(0, 0.4f).SetEase(Ease.OutExpo);
            sets[2].DOAnchorPosX(1700, 0.4f).SetEase(Ease.OutExpo);
        }

    }
    // 장르 선택 -> 프로필
    public void ClickSelectGenreToProfile()
    {
        if (CheckButtonCount())
        {
            sets[1].DOAnchorPosX(-1700, 0.4f).SetEase(Ease.OutExpo);
            sets[2].DOAnchorPosX(0, 0.4f).SetEase(Ease.OutExpo);
            // 아이디 넘기고 장르 넘기고
            profileText[0].text = PlayerPrefs.GetString("UserID");
            profileText[1].text = genres[0] + ", " + genres[1] + ", " + genres[2];
            PlayerPrefs.SetString("FirstGenre", genres[0]); PlayerPrefs.SetString("SecondGenre", genres[1]); PlayerPrefs.SetString("ThirdGenre", genres[2]);
        }
    }
    // 프로필 -> 장르 선택
    public void ClickProfileToSelectGenre()
    {
        sets[1].DOAnchorPosX(0, 0.4f).SetEase(Ease.OutExpo);
        sets[2].DOAnchorPosX(1700, 0.4f).SetEase(Ease.OutExpo);
    }

    public void OnClickBackToLogIn()
    {
        SceneManager.LoadScene("ShowLoginScene_C");
    }
}
