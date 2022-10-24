using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class KeyBarMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 savePosition;
    bool isDrag = false;
    public GameObject content;

    RectTransform rt;
    RectTransform rtContent;

    public GameObject showFrameBase;
    public GameObject showFrame;
    Text showFrameText;
    Image showFrameBaseImg;

    public InputField frameInputField;
    public GameObject frameInputFieldtxt;
    Text frameInputFieldText;

    int frame;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        // keybar를 드래그해서 x축만 이동시키고 싶다
        this.transform.position = new Vector2(Input.mousePosition.x, transform.position.y);
        savePosition = this.transform.position;

        // 현재 몇 프레임인지 텍스트로 표시
        ShowFrame();

        // FrameInputField는 드래그 할 때 frame값을 따라가고
        frameInputFieldText.text = frame.ToString();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        showFrameBaseImg.enabled = false;
        showFrameText.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        rtContent = content.GetComponent<RectTransform>();
        showFrameText = showFrame.GetComponent<Text>();
        showFrameBaseImg = showFrameBase.GetComponent<Image>();
        showFrameBaseImg.enabled = false;
        showFrameText.enabled = false;

        frameInputFieldText = frameInputFieldtxt.GetComponent<Text>();
        //frameInputField에서 Enter키 누르면 호출되는 함수 등록
        frameInputField.onEndEdit.AddListener(onEndEdit);
    }

    // Update is called once per frame
    void Update()
    {
        // KeyBar 움직임 제한
        Vector2 rtPos = rt.anchoredPosition;
        rt.anchoredPosition = new Vector2(Mathf.Clamp(rtPos.x, -538f, 950f), rtPos.y);

        // 현재 몇 프레임인지 계산
        KeyBarFrame();
    }

    // 현재 몇 프레임인지 계산
    public void KeyBarFrame()
    {
        frame = ((int)(- rtContent.anchoredPosition.x + rt.anchoredPosition.x + 538));
    }

    // 현재 몇 프레임인지 텍스트로 표시
    public void ShowFrame()
    {
        showFrameBaseImg.enabled = true;
        showFrameText.enabled = true;
        showFrameText.text = frame.ToString();
    }

    // FrameInputField는 드래그 할 때 frame값을 따라가고
    // FrameInputField 숫자를 넣고 enter를 치면 KeyBar가 그 frame값의 위치로 이동하고 싶다

    void onEndEdit(string s)
    {
        // FrameInputField 숫자를 넣고 enter를 치면 KeyBar가 그 frame값의 위치로 이동하고 싶다
        Vector2 rtPos = rt.anchoredPosition;
        rt.anchoredPosition = new Vector2(-538 + frame, rtPos.y);
        print(-538 + frame);
        print(rtPos.y);
    }
}