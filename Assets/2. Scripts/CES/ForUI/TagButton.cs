using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagButton : MonoBehaviour
{
    public Color originColor;
    public Color changeColor;

    public Image[] btns = new Image[5];
    public Transform[] listParent = new Transform[5];

    RectTransform ver1Content;

    // Start is called before the first frame update
    void Start()
    {
        ver1Content = gameObject.GetComponent<AddRectLength>().ver1Content;

        listParent[0].gameObject.SetActive(true);
        listParent[1].gameObject.SetActive(false);
        listParent[2].gameObject.SetActive(false);
        listParent[3].gameObject.SetActive(false);
        listParent[4].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 나는야 노가다의 신

    // 함수
    public void TagClick(int a)
    {
        // 반복
        for (int i = 0; i < listParent.Length; i++)
        {
            // 스크롤뷰 전부 다 false
            listParent[i].gameObject.SetActive(false);
            // 버튼 다 원래 색
            btns[i].color = originColor;
            //btns[i].image.color = new Color()
        }
        // 현재 스크롤뷰만 true
        listParent[a].gameObject.SetActive(true);
        // 현재 눌려있는 버튼만 색 다르게
        btns[a].color = changeColor;

        // findParent에다가 현재 스크롤뷰 렉트 트렌스폼 넣어줌
        RectTransform findParent = (RectTransform)listParent[a];

        // contentOfParent에다가 findParent의 콘텐트 넣어줌
        RectTransform contentOfParent = (RectTransform)listParent[a].GetChild(0).transform.GetChild(0);

        // childCount에다가 contentOfParent의 자식 개수
        int childCount = contentOfParent.transform.childCount;

        // row에다가 childCount를 4로 나눈 몫
        int row = childCount / 4;

        // remainder에다가 childCount를 4로 나눈 나머지
        int remainder = childCount % 4;

        // 나머지 0이면 row-1 * 450
        if (remainder == 0)
        {

            ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, 1265.583f + ((row - 1) * 450));
            findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
        }
        // 그게 아니면 row * 450
        else
        {
            ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, 1265.583f + (row * 450)/*ver1Content.sizeDelta.y + 450*/);
            findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
        }
    }
}
