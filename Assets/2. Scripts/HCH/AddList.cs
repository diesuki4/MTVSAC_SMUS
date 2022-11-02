using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Timeline.Types;

// ObjectInfo(Clone)이 TimelineObjectInputBase에 닿으면 이미지를 추가하고
// 리스트에 넣고 싶다

// 이미지를 추가하면서 TimelineTimerBase에 버튼을 추가하
// 리스트에 넣고 싶다


public class AddList : MonoBehaviour
{
    public static AddList instance;

    public GameObject objectListFactory;
    public Transform objectListParent;

    public GameObject timerListFactory;
    public Transform timerListParent;

    public List<GameObject> objectList;
    public List<GameObject> timerList;

    public GameObject timerBaseContent;
    RectTransform timerHeight;

    public GameObject objectInfo;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timerHeight = timerBaseContent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 리스트에 넣고 싶다()
        objectList = new List<GameObject>();
        objectList.AddRange(GameObject.FindGameObjectsWithTag("ObjectList"));
        //for(int i = 0; i < objectList.Count; i++)
        //{
        //    print(objectList[i]);
        //}

        timerList = new List<GameObject>();
        timerList.AddRange(GameObject.FindGameObjectsWithTag("TimerList"));

        for (int i = 0; i < objectList.Count; i++)
        {
            Vector2 objectListPos = objectList[i].transform.position;
            Vector2 timerListPos = timerList[i].transform.position;
            timerListPos.y = objectListPos.y;
            timerList[i].transform.position = timerListPos;
        }

    }

    // ObjectInfo(Clone)이 TimelineObjectInputBase에 닿으면 이미지를 추가하고
    // 리스트에 넣고 싶다
    public void AddObjectList()
    {
        // 만약 ObjectInfo(Clone)이 존재하고 마우스가 TimelineObjectInputBase에 있다면
        if (objectInfo != null)
        {
            ObjectInfoName objectInfoName = objectInfo.GetComponent<ObjectInfoName>();

            ObjectListName ObjectListName = Instantiate(objectListFactory, objectListParent).GetComponent<ObjectListName>();
            ObjectListName.SetObjectInfo(objectInfoName.guid, objectInfoName.tlType, objectInfoName.itemName);
            
            if (TimelineManager.Instance.isTimelineExist(ObjectListName.guid) == false)
                TimelineManager.Instance.NewTimeline(ObjectListName.guid, ObjectListName.tlType, ObjectListName.itemName);

            GameObject TimerList = Instantiate(timerListFactory, timerListParent);
            timerHeight.sizeDelta += Vector2.down * -50;
        }
        // ObjectInfo(Clone)이 TimelineObjectInputBase에 닿으면 이미지를 추가하고
        // 리스트에 넣고 싶다
    }
}
