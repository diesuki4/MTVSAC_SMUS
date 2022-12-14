using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;
// ObjectList가 isSelected인 상태에서 + 버튼을 누르면 Key를 생성하여 KeyParent의 자식으로 넣고 싶다 (Key의 X값 : KeyBar의 X값, Y값 : isSelected 상태인 ObjectList의 Y값)

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    GameObject ObjectKey;
    public GameObject objectKeyFactory;
    public Transform keyParent;

    public KeyBarMove keyBarMove;

    public Transform keyBar;
    Transform objectList;

    public List<GameObject> objectKeyList;

    public KeyManager()
    {
        instance = this;
        objectKeyList = new List<GameObject>();
    }

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
    }

    // ObjectList가 isSelected인 상태에서 + 버튼을 누르면 Key를 생성하여 KeyParent의 자식으로 넣고 싶다 (Key의 X값 : KeyBar의 X값, Y값 : isSelected 상태인 ObjectList의 Y값)
    public void OnClickAddObjectKey()
    {
        if (AddList.instance.objectList.Count > 0)
        {
            ObjectListName objectListName = objectList.GetComponent<ObjectListName>();
            TimelineObject tl_object = BuildingSystem.Instance.getTimelineObject(objectListName.guid);

            ObjectKey = Instantiate(objectKeyFactory, keyParent);
            objectKeyList.Add(ObjectKey);
            ObjectKey.transform.position = new Vector2(keyBar.position.x, objectList.position.y);
            ObjectKey.GetComponent<TimelineKey>().SetKeyInfo(tl_object.guid, keyBarMove.frame);
            TimelineManager.Instance.AddKey(tl_object.guid, keyBarMove.frame, tl_object.isActive, tl_object.transform);
        }
    }

    public void AddObjectKey(ObjectListName objectListName, TL_Types.Key key, float posY)
    {
        ObjectKey = Instantiate(objectKeyFactory, keyParent);
        ObjectKey.transform.position = new Vector2(key.frame - 323, posY);
        ObjectKey.GetComponent<TimelineKey>().SetKeyInfo(objectListName.guid, key);
        objectKeyList.Add(ObjectKey);
    }

    // 만약 objectkeylist의 수가 0보다 크고 
    // subLineManager.instance.results[0].gameObject의 layer가 objectkey일때
    // 좌클릭하면  subLineManager.instance.results[0].gameObject가 isSelected된다
}
