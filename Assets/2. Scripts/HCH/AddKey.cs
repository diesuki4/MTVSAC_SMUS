using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ObjectList가 isSelected인 상태에서 + 버튼을 누르면 Key를 생성하여 KeyParent의 자식으로 넣고 싶다 (Key의 X값 : KeyBar의 X값, Y값 : isSelected 상태인 ObjectList의 Y값)

public class AddKey : MonoBehaviour
{
    public GameObject objectKeyFactory;
    public Transform keyParent;

    public Transform keyBar;
    Transform objectList;

    public List<GameObject> objectKeyList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ObjectList의 list를 돌아가며 isSelected를 체크하고
        // 체크된 애를 objectList에 넣는다
        if (AddList.instance.objectList.Count > 0)
        {
            for (int i = 0; i < AddList.instance.objectList.Count; i++)
            {
                if (AddList.instance.objectList[i].GetComponent<ObjectListManager>().isSelected == true)
                {
                    objectList = AddList.instance.objectList[i].transform;
                }
            }
        }
        AddObjectKeyList();
    }

    // ObjectList가 isSelected인 상태에서 + 버튼을 누르면 Key를 생성하여 KeyParent의 자식으로 넣고 싶다 (Key의 X값 : KeyBar의 X값, Y값 : isSelected 상태인 ObjectList의 Y값)
    public void OnClickAddObjectKey()
    {
        if (AddList.instance.objectList.Count > 0)
        {
            GameObject ObjectKey = Instantiate(objectKeyFactory, keyParent);
            ObjectKey.transform.position = new Vector2(keyBar.position.x, objectList.position.y);
        }
    }

    // 생성된 key를 keyList에 저장
    public void AddObjectKeyList()
    {
        objectKeyList = new List<GameObject>();
        objectKeyList.AddRange(GameObject.FindGameObjectsWithTag("ObjectKeyList"));
    }
}
