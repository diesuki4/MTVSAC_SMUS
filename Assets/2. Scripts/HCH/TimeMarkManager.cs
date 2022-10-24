using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 긴 마크 1개, 짧은 마크 4개을 한 세트로 하고 싶다
// 각 마크들 간 X 간격은 10으로 하고 싶다
// 총 길이는 1800프레임(1분), width가 1800이다

public class TimeMarkManager : MonoBehaviour
{
    public GameObject longMarkFactory;
    public GameObject shortMarkFactory;
    public Transform timeAreaContent;

    RectTransform rtLong;
    RectTransform rtShort;

    Text frameText;

    // 긴 마크 간격
    public float longGap;
    // 짧은 마크 간격
    public float shortGap;
    // 총길이
    public float totalWidth;
    // 프레임 텍스트 간격
    public float frameGap;

    // rtLong의 PosX
    float longPosX;
    // rtShort의 PosX
    float shortPosX;

    // Start is called before the first frame update
    void Start()
    {
        // 긴 마크 찍기
        AddLongMark();
        // 짧은 마크 찍기
        AddShortMark();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 긴 마크 찍기
    public void AddLongMark()
    {
        for (int i = 0; i < totalWidth / longGap; i++)
        {
            GameObject longMark = Instantiate(longMarkFactory, timeAreaContent);
            rtLong = longMark.GetComponent<RectTransform>();
            longPosX += longGap;
            rtLong.anchoredPosition = new Vector2(longPosX, 15);
            // 텍스트로 프레임 띄우고 싶다
            frameText = longMark.GetComponentInChildren<Text>();
            // 프레임 간격 표시 여부
            if((longPosX % frameGap) != 0)
            {
                frameText.enabled = false;
            }
            frameText.text = longPosX.ToString();
        }
    }

    // 짧은 마크 찍기
    public void AddShortMark()
    {
        for (int i = 0; i < totalWidth / shortGap; i++)
        {
            GameObject shortMark = Instantiate(shortMarkFactory, timeAreaContent);
            rtShort = shortMark.GetComponent<RectTransform>();
            shortPosX += shortGap;
            rtShort.anchoredPosition = new Vector2(shortPosX, 7.5f);
        }
    }
}
