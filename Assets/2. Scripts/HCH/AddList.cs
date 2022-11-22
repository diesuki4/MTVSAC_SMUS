using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Timeline.Types;
using Timeline.Timeline;

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

    // 오브젝트리스트 생성시 저장할 정보들
    //Vector3 firstKeyPosition;
    //Quaternion firstKeyRotation;
    //bool firstKeyActive;

    public AddList()
    {
        instance = this;
        objectList = new List<GameObject>();
        timerList = new List<GameObject>();
    }

    private void Awake()
    {
        timerHeight = timerBaseContent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < objectList.Count; i++)
        //{
        //    print(objectList[i]);
        //}

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
    public void AddObjectList(ObjectInfoName objectInfoName)
    {
        // 만약 ObjectInfo(Clone)이 존재하고 마우스가 TimelineObjectInputBase에 있다면
        if (objectInfoName != null)
        {
            ObjectListName objectListName = Instantiate(objectListFactory, objectListParent).GetComponent<ObjectListName>();
            objectListName.SetObjectInfo(objectInfoName.guid, objectInfoName.tlType, objectInfoName.itemName);

            // 리스트에 넣고 싶다()
            //objectList.AddRange(GameObject.FindGameObjectsWithTag("ObjectList"));
            objectList.Add(objectListName.gameObject);
            //// 오브젝트의 처음 데이터 저장
            //firstKeyPosition = BuildingSystem.Instance.getTimelineObject(objectInfoName.guid).transform.position;
            //firstKeyRotation = BuildingSystem.Instance.getTimelineObject(objectInfoName.guid).transform.rotation;
            //firstKeyActive = BuildingSystem.Instance.getTimelineObject(objectInfoName.guid).isActive;

            GameObject TimerList = Instantiate(timerListFactory, timerListParent);
            //timerList.AddRange(GameObject.FindGameObjectsWithTag("TimerList"));
            timerList.Add(TimerList);
            timerHeight.sizeDelta += Vector2.down * -50;
        }
        // ObjectInfo(Clone)이 TimelineObjectInputBase에 닿으면 이미지를 추가하고
        // 리스트에 넣고 싶다
    }

    public ObjectListName AddObjectList(string guid, TL_Timeline timeline)
    {
        if (TimelineManager.Instance.isTimelineExist(guid))
        {
            ObjectListName objectListName = Instantiate(objectListFactory, objectListParent).GetComponent<ObjectListName>();
            objectListName.SetObjectInfo(guid, timeline.tlType, timeline.itemName);

            objectList.Add(objectListName.gameObject);

            GameObject TimerList = Instantiate(timerListFactory, timerListParent);
            timerList.Add(TimerList);

            timerHeight.sizeDelta += Vector2.down * -50;

            return objectListName;
        }

        return null;
    }
}
