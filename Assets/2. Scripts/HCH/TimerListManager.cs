using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// TimerList의 width를 TimerBaseContent의 width와 항상 같게 하고 싶다

// i가 같은 ObjectList가 isSelected될 때 i가 같은 ObjectList의 색깔을 따라가고 싶다
// 그렇지 않으면 원래의 색깔로 돌아오게 하고 싶다


public class TimerListManager : MonoBehaviour
{
    RectTransform rt;
    GameObject timerBaseContent;
    RectTransform tContentRect;

    Color originColor;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        timerBaseContent = GameObject.Find("TimerBaseContent");
        tContentRect = timerBaseContent.GetComponent<RectTransform>();

        originColor = this.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        SyncColor();
    }

    public void SyncWidth()
    {
        Rect rect = rt.rect;
        float timerlistRt = rt.rect.width;
        float contentRt = tContentRect.rect.width;
        timerlistRt = contentRt;
        rect.width = timerlistRt;
    }


    public void SyncColor()
    {
        for (int i = 0; i < AddList.instance.objectList.Count; i++)
        {
            // i가 같은 ObjectList가 isSelected될 때 i가 같은 ObjectList의 색깔을 따라가고 싶다
            if (AddList.instance.objectList[i].GetComponent<ObjectListManager>().isSelected)
            {
                AddList.instance.timerList[i].GetComponent<Image>().color = AddList.instance.objectList[i].GetComponent<ObjectListManager>().focusColor;
            }
            // 그렇지 않으면 원래의 색깔로 돌아오게 하고 싶다
            else
            {
                AddList.instance.timerList[i].GetComponent<Image>().color = originColor;
            }
            // 같은 라인의 objectlist가 destroy될 때 같이 파괴하고 싶다
            //if (AddList.instance.objectList[i] == null)
            //{
            //    print("123");
            //    Destroy(gameObject);
            //}
        }
    }

}
