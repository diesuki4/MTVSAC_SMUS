using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRectLength : MonoBehaviour
{
    public RectTransform ver1Content;
    public RectTransform ver2;
    public RectTransform ver2Content;

    public GameObject buttonPrefab;

    public RectTransform[] listParent = new RectTransform[5];

    float curTime = 0;

    bool justOne = false;

    public RectTransform findParent;
    public RectTransform contentOfParent;

    // Start is called before the first frame update
    void Start()
    {
        // 애초에 걍 시작할 때 길이 맞춰줘야하네... 
    }

    // Update is called once per frame
    void Update()
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
                GameObject listButton = Instantiate(buttonPrefab);
                listButton.transform.SetParent(content, false);
            }
        }
    }
}
