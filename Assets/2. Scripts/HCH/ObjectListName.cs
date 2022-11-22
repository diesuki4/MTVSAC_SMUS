using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Timeline.Types;
// objectList를 추가할 때, 텍스트 내용을 받아와서
// 버튼의 텍스트에 넣고 싶다
public class ObjectListName : MonoBehaviour
{
    string ListText;
    Text objectListText;

    [HideInInspector] public string guid;
    [HideInInspector] public TL_ENUM_Types tlType;
    [HideInInspector] public string itemName;

    void Awake()
    {
        objectListText = this.GetComponentInChildren<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //objectListText.text = ObjectCheck.instance.saveName.Replace("(Clone)", "");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetObjectInfo(string guid, TL_ENUM_Types tlType, string itemName)
    {
        this.guid = guid;
        this.tlType = tlType;
        this.itemName = itemName;
        objectListText.text = itemName;
    }
}
