using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ObjectList를 누르면 선택 상태로 만들고
// 선택 상태일 때는 색깔을 변경하고 싶다
// 선택 상태를 해제하면 다시 원래 색깔로 변경하고 싶다
// 선택 상태에서 delete를 누르면 destroy하고 싶다
// destroy하면 TimelineTimerBase의 Content 길이를 -50 해준다

public class ObjectListManager : MonoBehaviour
{
    public bool isSelected;
    Image img;
    public Color focusColor = new Color32(168, 255, 255, 255);
    Color originColor;
    public GameObject txt;

    GameObject timerBaseContent;
    RectTransform timerHeight;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        img = GetComponent<Image>();
        originColor = img.color;
        timerBaseContent = GameObject.Find("TimerBaseContent");
        timerHeight = timerBaseContent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // graphic raycaster에 이 오브젝트가 닿고
        if (0 < SubLineManager.instance.results.Count && SubLineManager.instance.results[0].gameObject == txt)
        {
            // isSelected가 false라면 선택 상태로 하고 
            if (isSelected == false)
            {
                ObjectlistSelect();
            }
            // isSelected가 true라면 선택 상태를 해제한다
            else
            {
                ObjecctlistDeselect();
            }
            // 다른 곳을 클릭해도 선택 상태를 해제한다    
        }
        else
        {
            ObjecctlistDeselect();
        }

        // 선택 상태일 때 delete를 누르면 destroy하고 싶다
        if (isSelected == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                timerHeight.sizeDelta += Vector2.down * 50;
                Destroy(gameObject);
            }
        }
        print(txt);
    }

    // 좌클릭시 선택 상태로 만들고 싶다
    // 선택 상태인 동안 색깔을 바꾸고 싶다
    public void ObjectlistSelect()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isSelected = true;
            print("Select");
            img.color = focusColor;
        }
    }

    // 좌클릭시 선태 상태를 해제하고 싶다
    // 선택 상태 해제 시 색깔을 원래대로 하고 싶다
    public void ObjecctlistDeselect()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isSelected = false;
            print("Deselect");
            img.color = originColor;
        }
    }

}
