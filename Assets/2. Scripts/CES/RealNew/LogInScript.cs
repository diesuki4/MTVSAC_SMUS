using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LogInScript : MonoBehaviour
{
    public RectTransform popUp;
    public Button[] iWants = new Button[2]; // 0 = 아티스트, 1 = 관객
    public InputField[] users = new InputField[2];// 0 = ID, 1 = PW
    public Transform infoImage;
    public Text InfoImageText;
    public bool amIArtist = false;
    bool justOne = true;
    public Button[] goWhat = new Button[2];

    // Start is called before the first frame update
    void Start()
    {
        popUp.gameObject.SetActive(false);
        iWants[0].gameObject.SetActive(false);
        iWants[1].gameObject.SetActive(false);
        infoImage.gameObject.SetActive(false);
        goWhat[1].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 스크롤씬으로 옮기기
    public void LoadLoad()
    {
        if (PlayerPrefs.GetString("MyVer") == "Artist")
        {
            // 아티스트일때
        }
        else
        {
            // 관객일때
        }
    }
    
    // 인풋필드에 한글자라도 적혀있어야 넘길 수 있겡
    bool CheckInputFieldLength()
    {
        if (users[0].text.Length > 0 && users[1].text.Length > 0) return true;
        else return false;
    }

    // 누르면 계정 선택 팝업
    public void ClickForPopUp()
    {
        if (CheckInputFieldLength())
        {
            popUp.gameObject.SetActive(true);
            popUp.DOScale(new Vector2(1, 1), 0.3f);
        }
    }

    // 별, 하트
    public void IconClick()
    {
        string myver = "";
        if (justOne)
        {
            myver = PlayerPrefs.GetString("MyVer");
            if (myver == "Artist") amIArtist = true;
            else amIArtist = false;
            justOne = false;
        }

        amIArtist = !amIArtist;
        ChangeIcon();
    }
    void ChangeIcon()
    {
        if (amIArtist)
        {
            iWants[0].gameObject.SetActive(true);
            iWants[1].gameObject.SetActive(false);
            PlayerPrefs.SetString("MyVer", "Artist");
        }
        else
        {
            iWants[0].gameObject.SetActive(false);
            iWants[1].gameObject.SetActive(true);
            PlayerPrefs.SetString("MyVer", "Audience");
        }
    }

    // 팝업 - 아티스트
    public void IWantArtist()
    {
        popUp.DOScale(new Vector2(0.6f, 0.6f), 0.3f);
        popUp.gameObject.SetActive(false);
        iWants[0].gameObject.SetActive(true);
        iWants[1].gameObject.SetActive(false);
        PlayerPrefs.SetString("MyVer", "Artist");

        goWhat[0].gameObject.SetActive(false);
        goWhat[1].gameObject.SetActive(true);
    }
    // 팝업 - 관객
    public void IWantAudience()
    {
        popUp.DOScale(new Vector2(0.6f, 0.6f), 0.3f);
        popUp.gameObject.SetActive(false);
        iWants[0].gameObject.SetActive(false);
        iWants[1].gameObject.SetActive(true);
        PlayerPrefs.SetString("MyVer", "Audience");

        goWhat[0].gameObject.SetActive(false);
        goWhat[1].gameObject.SetActive(true);
    }

    // 포인터 엔터 됐을 때 별 설명
    public void InfoInVer()
    {
        infoImage.gameObject.SetActive(true);
        string ver = PlayerPrefs.GetString("MyVer");
        if (ver == "Artist")
        {
            InfoImageText.text = "지금은 " + "<color=#FEBA66>" + "아티스트" + "</color>" + $"\n" + $"\n" + "클릭 시 " + "<color=#FF3939>" + "관객" + "</color>" + "으로 전환돼요";
        }
        else if (ver == "Audience")
        {
            InfoImageText.text = "지금은 " + "<color=#FF3939>" + "관객" + "</color>" + $"\n" + $"\n" + "클릭 시 " + "<color=#FEBA66>" + "아티스트" + "</color>" + "로 전환돼요";
        }
    }
    public void InfoOutVer()
    {
        infoImage.gameObject.SetActive(false);
    }

    public void CloseButton()
    {
        popUp.gameObject.SetActive(false);
    }
}
