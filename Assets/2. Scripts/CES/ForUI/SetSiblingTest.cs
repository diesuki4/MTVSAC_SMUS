using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSiblingTest : MonoBehaviour
{
    public Transform[] btns = new Transform[5];

    public Transform parentObject;

    Transform frontObject;
    Transform firstObject;

    RectTransform[] btnsRect = new RectTransform[5];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            btnsRect[i] = btns[i].GetComponent<RectTransform>();
        }
        frontObject = parentObject.GetChild(5);
        firstObject = parentObject.GetChild(1);
        OnClickRightButton();
        OnClickRightButton();
    }

    // Update is called once per frame
    void Update()
    {
        frontObject = parentObject.GetChild(5);
        firstObject = parentObject.GetChild(1);
    }

    public void OnClickRightButton()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            if (frontObject.name == btns[i].name)
            {
                if (i < 4)
                {
                    btns[i + 1].SetSiblingIndex(5);
                    firstObject.SetSiblingIndex(2);
                    //// ㅋㅋ 노가다 간다
                    if (i == 0)
                    {
                        btnsRect[4].anchoredPosition = new Vector2(-200, 0);
                        btnsRect[0].anchoredPosition = new Vector2(-100, 0);
                        btnsRect[1].anchoredPosition = new Vector2(0, 0);
                        btnsRect[2].anchoredPosition = new Vector2(100, 0);
                        btnsRect[3].anchoredPosition = new Vector2(200, 0);
                    }
                    else if (i == 1)
                    {
                        btnsRect[0].anchoredPosition = new Vector2(-200, 0);
                        btnsRect[1].anchoredPosition = new Vector2(-100, 0);
                        btnsRect[2].anchoredPosition = new Vector2(0, 0);
                        btnsRect[3].anchoredPosition = new Vector2(100, 0);
                        btnsRect[4].anchoredPosition = new Vector2(200, 0);
                    }
                    else if (i == 2)
                    {
                        btnsRect[1].anchoredPosition = new Vector2(-200, 0);
                        btnsRect[2].anchoredPosition = new Vector2(-100, 0);
                        btnsRect[3].anchoredPosition = new Vector2(0, 0);
                        btnsRect[4].anchoredPosition = new Vector2(100, 0);
                        btnsRect[0].anchoredPosition = new Vector2(200, 0);
                    }
                    else if (i == 3)
                    {
                        btnsRect[2].anchoredPosition = new Vector2(-200, 0);
                        btnsRect[3].anchoredPosition = new Vector2(-100, 0);
                        btnsRect[4].anchoredPosition = new Vector2(0, 0);
                        btnsRect[0].anchoredPosition = new Vector2(100, 0);
                        btnsRect[1].anchoredPosition = new Vector2(200, 0);
                    }
                }
                else if (i == 4)
                {
                    btns[0].SetSiblingIndex(5);
                    firstObject.SetSiblingIndex(2);

                    btnsRect[3].anchoredPosition = new Vector2(-200, 0);
                    btnsRect[4].anchoredPosition = new Vector2(-100, 0);
                    btnsRect[0].anchoredPosition = new Vector2(0, 0);
                    btnsRect[1].anchoredPosition = new Vector2(100, 0);
                    btnsRect[2].anchoredPosition = new Vector2(200, 0);
                }
            }
        }
    }

    public void OnClickLeftButton()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            if (frontObject.name == btns[i].name)
            {
                if (i > 0)
                {
                    btns[i - 1].SetSiblingIndex(5);
                }
                else if (i == 0)
                {
                    btns[4].SetSiblingIndex(5);
                }
            }
        }
    }
}
