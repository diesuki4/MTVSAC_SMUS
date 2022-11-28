using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class AudienceScrollScript : MonoBehaviour
{
    // 생성될 버튼 프리팹
    public GameObject prefab;

    // 장르별 공연개수, 탭
    public int[] genreNum = new int[3];
    public RectTransform[] genreTab = new RectTransform[3];

    // 스크롤뷰의 콘텐트
    public RectTransform content;

    // 시작할 때 한 번만
    bool justOne = true;

    // 옵션창
    public RectTransform option;

    // 유저 이름
    public Text userID;
    // 장르 버튼 텍스트
    public Text[] genreNames = new Text[3];

    // Start is called before the first frame update
    void Start()
    {
        genreTab[1].gameObject.SetActive(false);
        genreTab[2].gameObject.SetActive(false);

        option.gameObject.SetActive(false);

        userID.text = PlayerPrefs.GetString("UserID");
        genreNames[0].text = PlayerPrefs.GetString("FirstGenre");
        genreNames[1].text = PlayerPrefs.GetString("SecondGenre");
        genreNames[2].text = PlayerPrefs.GetString("ThirdGenre");
    }

    // Update is called once per frame
    void Update()
    {
        SettingTabSize();
        StartCreate();
        ChangeContentSize();
    }

    // 개수에 따라 탭 사이즈 변경
    void SettingTabSize()
    {
        if (justOne)
        {
            int zul = 0;

            for (int i = 0; i < genreTab.Length; i++)
            {
                if (genreNum[i] % 4 == 0) zul = -1;

                zul += (genreNum[i] / 4) + 1; // 몇 줄인지 구하고
                genreTab[i].sizeDelta = new Vector2(genreTab[i].sizeDelta.x, 400 * zul);

                zul = 0;
            }
        }
    }

    // 개수에 따라 시작하자마자 생성
    void StartCreate()
    {
        if (justOne)
        {
            // 장르탭 개수만큼 돌아
            for (int i = 0; i < genreTab.Length; i++)
            {
                // 정해준 개수만큼 돌아
                for (int j = 0; j < genreNum[i]; j++)
                {
                    Instantiate(prefab, genreTab[i]);
                }
            }
            justOne = false;
        }
    }

    // 콘텐트 사이즈도 바뀌어야 함
    void ChangeContentSize()
    {
        for (int i = 0; i < genreTab.Length; i++)
        {
            if (genreTab[i].gameObject.activeSelf)
            {
                // 그리드 탑 + 장르버튼 세로 + 간격 + 장르탭 세로
                float contentY = 56 + 400 + 86 + 100 + 86 + genreTab[i].sizeDelta.y;
                content.sizeDelta = new Vector2(content.sizeDelta.x, contentY);
            }
        }
    }

    // 버튼 누르면 그에 따른 장르탭이 뜨게
    public void ClickGenreButton(int i)
    {
        for (int j = 0; j < genreTab.Length; j++)
        {
            genreTab[j].gameObject.SetActive(false);
        }
        genreTab[i].gameObject.SetActive(true);
    }

    // 옵션 버튼 누르면 옵션창 뜨게
    public void ClickOptionButton()
    {
        option.gameObject.SetActive(true);
        option.DOScale(new Vector2(0.9f, 0.9f), 0.2f).SetEase(Ease.OutBounce);
    }

    // 옵선창 끄자
    public void ClickOptionCloseButton()
    {
        option.DOScale(new Vector2(0.6f, 0.6f), 0.3f).SetEase(Ease.InOutExpo);
        option.gameObject.SetActive(false);
    }

    // 버튼 누르면 입장할지 말지
}
