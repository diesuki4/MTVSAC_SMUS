using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Timeline.Types;
// 텍스트에 objectInfo의 이름을 넣고 싶다
// 시작할 때 ObjectInfo의 BoxCollider를 끄고
// 좌클릭 해제시 파괴하기전에 BoxCollider를 키고 싶다
public class ObjectInfoName : MonoBehaviour
{
    Text objectInfoText;

    [HideInInspector] public string guid;
    [HideInInspector] public TL_ENUM_Types tlType;
    [HideInInspector] public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        objectInfoText = this.GetComponent<Text>();
        objectInfoText.text = ObjectCheck.instance.hitInfo.transform.name;

        TimelineObject tlObject = BuildingSystem.Instance.objectToPlace.GetComponent<TimelineObject>();
        guid = tlObject.guid;
        tlType = tlObject.tlType;
        itemName = tlObject.itemName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 좌클릭 해제시 파괴하기전에 BoxCollider를 키고 싶다
    public void BoxColliderOnOff()
    {
        objectInfoText.enabled = false;
    }
}
