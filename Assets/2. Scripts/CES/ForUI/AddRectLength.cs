using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AddRectLength : MonoBehaviour
{
    // 기본 스크롤뷰 (모든 스크롤뷰의 엄마)
    public RectTransform ver1Content;
    public RectTransform ver2;
    public RectTransform ver2Content;

    // 생성될 버튼 프리팹
    public Button buttonPrefab;

    // 자식 스크롤뷰들
    public RectTransform[] listParent = new RectTransform[5];

    float curTime = 0;
    
    // 딱 한 번만
    bool justOne = false;

    [Header("다른 스크립트에서 써야함...")]
    // listParent의 현재 i 에 해당하는 스크롤뷰
    public RectTransform findParent;

    // findParent의 Content
    public RectTransform contentOfParent;

    [Header("버튼 몇 개 만들거야")]
    public int[] btnNum = new int[5];
    public Sprite[] btnImage;

    bool startAdd = true;

    // Start is called before the first frame update
    void Start()
    {
        // 애초에 걍 시작할 때 길이 맞춰줘야하네... 
    }

    // Update is called once per frame
    void Update()
    {
        if (startAdd)
        {
            StartAddButton();
        }
        WhenAddRow();
    }

    void WhenAddRow()
    {
        if (contentOfParent == null) return;
        int contentChild = contentOfParent.transform.childCount;

        // ver2Content 자식개체 % 4 한 순간
        if (contentChild % 4 == 1 && !justOne)
        {
            curTime += Time.deltaTime;
            // 딱 한 번
            // AddRow 실행
            if (curTime > 0.1f)
            {
                AddRow();
                curTime = 0;
                justOne = true;
                print("AddRow 실행");
            }
        }
        else if (contentChild % 4 != 1)
        {
            justOne = false;
            //print("justOne false");
        }
    }

    // 스크롤뷰 길이 늘리기
    public void AddRow()
    {
        ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, ver1Content.sizeDelta.y + 450);
        findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
    }

    // 프리팹 버튼 추가하기
    public void OnClickAddButton()
    {
        // 내가 원하는 거 : 현재 실행되어있는 스크롤뷰에 넣기
        for (int i = 0; i < listParent.Length; i++)
        {
            // 실행되어있는 거 찾아서
            if (listParent[i].gameObject.activeSelf == true)
            {
                findParent = listParent[i];

                // 걔의 콘텐트를 찾아야함
                //print(listParent[i].GetChild(0).transform.GetChild(0).transform);
                Transform content = listParent[i].GetChild(0).transform.GetChild(0);

                // 일단 버튼 만들고
                contentOfParent = (RectTransform)content;
                Button listButton = Instantiate(buttonPrefab);
                listButton.transform.SetParent(content, false);
            }
        }
    }

    // 시작할 때 정해진 수만큼 냅다 만들어야함
    void StartAddButton()
    {
        // listParent[i]에 btnNum[i]개 만큼 만들기
        // 일단 돌면서 만들어야하니까
        for (int i = 0; i < listParent.Length; i++)
        {
            // 얘의 콘텐트를 찾아서
            Transform content = listParent[i].GetChild(0).transform.GetChild(0);
            print(content);

            // btnNum[i]개 만큼 버튼 만들어
            for (int j = 0; j < btnNum[i]; j++)
            {
                print(btnNum[i]);
                Button listButton = Instantiate(buttonPrefab);
                listButton.transform.SetParent(content, false);
                if (btnImage[j] == null) return;
                listButton.GetComponent<Image>().sprite = btnImage[j];
            }
            // 이미지 지워
            Array.Clear(btnImage, 0, btnNum[i]);
        }
        startAdd = false;
    }
}
