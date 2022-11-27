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

    ObjectListName oln;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        img = GetComponent<Image>();
        originColor = img.color;
        timerBaseContent = GameObject.Find("TimerBaseContent");
        timerHeight = timerBaseContent.GetComponent<RectTransform>();
        oln = this.GetComponent<ObjectListName>();
    }

    // Update is called once per frame
    void Update()
    {
        //// graphic raycaster에 이 오브젝트가 닿고
        //if (0 < SubLineManager.instance.results.Count && SubLineManager.instance.results[0].gameObject == txt)
        //{
        //    // isSelected가 false라면 선택 상태로 하고 
        //    if (isSelected == false)
        //    {
        //        ObjectlistSelect();
        //    }
        //    // isSelected가 true라면 선택 상태를 해제한다
        //    else
        //    {
        //        ObjecctlistDeselect();
        //    }
        //    // 다른 곳을 클릭해도 선택 상태를 해제한다    
        //}
        //else
        //{
        //    ObjecctlistDeselect();
        //}

        if (isSelected == false)
        {
            img.color = originColor;
        }
        else
        {
            img.color = focusColor;
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
        if (SubLineManager.instance.results.Count <= 0) return;
        if (SubLineManager.instance.results[0].gameObject != null)
        {
            Deselect();
        }
    }

    // 좌클릭시 선택 상태로 만들고 싶다
    // 선택 상태인 동안 색깔을 바꾸고 싶다
    // 좌클릭시 선택 상태를 해제하고 싶다
    // 선택 상태 해제 시 색깔을 원래대로 하고 싶다
    public void OnClickSelect()
    {
        // 다른 버튼을 누르면 모든버튼의 isSelected를 false로 하고
        for (int i = 0; i < AddList.instance.objectList.Count; i++)
        {
            AddList.instance.objectList[i].GetComponent<ObjectListManager>().isSelected = false;
        }
        // 누른 버튼의 isSelected를 true로 하고 싶다
        isSelected = true;

        // 버튼을 누르면 그 버튼에 해당하는 오브젝트의 아웃라인을 활성화하고 싶다
        foreach (PlaceableObject po in BuildingSystem.Instance.objectList)
        {
            Outline ol = po.GetComponent<Outline>();
            if (ol == null) ol = po.GetComponentInChildren<Outline>();

            ol.enabled = false;
        }

        Outline outline = BuildingSystem.Instance.getTimelineObject(oln.guid).GetComponent<Outline>();
        if (outline == null) outline = BuildingSystem.Instance.getTimelineObject(oln.guid).GetComponentInChildren<Outline>();

        outline.enabled = true;
        BuildingSystem.Instance.objectToPlace = BuildingSystem.Instance.getTimelineObject(oln.guid).GetComponent<PlaceableObject>();
    }

    // KeyBar외의 오브젝트에 graphic raycaster가 닿은 상태에서 좌클릭을 하면 모든 버튼의 isSelected를 false로 하고 싶다
    public void Deselect()
    {
        if(SubLineManager.instance.results[0].gameObject.name != "KeyBarText")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                for (int i = 0; i < AddList.instance.objectList.Count; i++)
                {
                    AddList.instance.objectList[i].GetComponent<ObjectListManager>().isSelected = false;
                }
            }
        }
        else
        {
            return;
        }
    }
}
