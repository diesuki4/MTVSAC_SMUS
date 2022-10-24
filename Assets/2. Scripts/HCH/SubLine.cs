using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Subline을 클릭했을 때 선택상태로 만들고 color를 바꾸고 싶다
// 선택된 상태에서 delete를 누를 때 destroy하고 싶다

// Subline과 TimerBaseContent의 PosX를 같이 이동하고 싶다

public class SubLine : MonoBehaviour
{
    public bool isSelected;
    Image img;
    Color focusColor = new Color32(0, 140, 26, 255);
    Color originColor;

    RectTransform sublineRect;
    GameObject timerBaseContent;
    RectTransform timerRect;

    float startCont;
    float updateCont;
    float startBar;
    float updateBar;
    float offset;

    Color hideColor;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        img = GetComponent<Image>();
        originColor = img.color;

        sublineRect = this.GetComponent<RectTransform>();
        timerBaseContent = GameObject.Find("TimerBaseContent");
        timerRect = timerBaseContent.GetComponent<RectTransform>();

        // 시작할 때 Subline X값 저장
        startBar = sublineRect.transform.position.x;
        // 시작할 때 Content X값 저장
        startCont = timerRect.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // graphic raycaster에 이 오브젝트가 닿고
        if (0 < SubLineManager.instance.results.Count && SubLineManager.instance.results[0].gameObject == this.gameObject)
        {
            // isSelected가 false라면 선택 상태로 하고 
            if (isSelected == false)
            {
                SublineSelect();
            }
            // isSelected가 true라면 선택 상태를 해제한다
            else
            {
                SublineDeselect();
            }
        // 다른 곳을 클릭해도 선택 상태를 해제한다    
        }
        else
        {
            SublineDeselect();
        }

        // 선택 상태일 때 delete를 누르면 destroy하고 싶다
        SublineDestroy();
        // Subline과 TimelineTimerContent의 PosX를 같이 이동하고 싶다
        SublineMoveWithContent();
        // 만약 PosX가 -536.5 보다 작으면 이미지의 알파값을 0으로 하고 싶다
        SublineHide();
    }

    // 좌클릭시 선택 상태로 만들고 싶다
    // 선택 상태인 동안 색깔을 바꾸고 싶다
    public void SublineSelect()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isSelected = true;
            img.color = focusColor;
        }
    }

    // 좌클릭시 선태 상태를 해제하고 싶다
    // 선택 상태 해제 시 색깔을 원래대로 하고 싶다
    public void SublineDeselect()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isSelected = false;
            img.color = originColor;
        }
    }

    public void SublineDestroy()
    {
        // 선택 상태일 때 delete를 누르면 destroy하고 싶다
        if (isSelected == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Destroy(gameObject);
            }
        }
    }

    // Subline과 TimelineTimerContent의 PosX를 같이 이동하고 싶다
    public void SublineMoveWithContent()
    {
        updateBar = sublineRect.transform.position.x;
        updateCont = timerRect.transform.position.x;
        offset = updateCont - startCont;
        updateBar = startBar + offset;

        sublineRect.transform.position = new Vector3(updateBar, sublineRect.transform.position.y, sublineRect.transform.position.z);
    }

    // 만약 PosX가 -536.5 보다 작으면 이미지의 알파값을 0으로 하고 싶다
    public void SublineHide()
    {
        if (sublineRect.anchoredPosition.x < -536.5f)
        {
            hideColor = img.color;
            hideColor.a = 0;
            img.color = hideColor;
            //hideColor = new Color32(0, 255, 26, 0);
        }
        else
        {
            hideColor = img.color;
            hideColor.a = 1;
            img.color = hideColor;
            //hideColor = originColor;
        }
    }
}
