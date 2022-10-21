using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Object")
        {
            // ObjectInfo(Clone)이 TimelineObjectInputBase에 닿으면 버튼을 추가하고 싶다
            GameObject ObjectList = Instantiate(objectListFactory, objectListParent);
            //for (int i = 0; i < objectList.Count; i++)
            //{
            //    Vector2 objectListPos = objectList[i].transform.position;
            //    Vector2 timerListPos = timerList[i].transform.position;
            //    timerListPos.y = objectListPos.y;
            //    timerList[i].transform.position = timerListPos;
            //}

            // 이미지를 추가하면서 TimelineTimerBase에 버튼을 추가하고 싶다 
            GameObject TimerList = Instantiate(timerListFactory, timerListParent);
            timerHeight.sizeDelta += Vector2.down * -50;
        }
    }
}
