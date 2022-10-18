using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// ObjectInfo(Clone)이 TimelineObjectInputBase에 닿으면 이미지를 추가하고
// 리스트에 넣고 싶다

// 이미지를 추가하면서 TimelineTimerBase에 버튼을 추가하
// 리스트에 넣고 싶다


public class AddList : MonoBehaviour
{
    public GameObject objectListFactory;
    public Transform objectListParent;

    public GameObject timerListFactory;
    public Transform timerListParent;

    List<GameObject> objectList;
    List<GameObject> timerList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 리스트에 넣고 싶다()
        objectList = new List<GameObject>();
        objectList.AddRange(GameObject.FindGameObjectsWithTag("ObjectList"));
        for(int i = 0; i < objectList.Count; i++)
        {
            print(objectList[i]);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Object")
        {
            // ObjectInfo(Clone)이 TimelineObjectInputBase에 닿으면 버튼을 추가하고 싶다
            GameObject objectList = Instantiate(objectListFactory, objectListParent);

            // 이미지를 추가하면서 TimelineTimerBase에 버튼을 추가하고 싶다 
            GameObject tierList = Instantiate(timerListFactory, timerListParent);
        }
    }
}
