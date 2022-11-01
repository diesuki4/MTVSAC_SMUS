using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 마우스 좌클릭 상태일 때 레이를 쏴서 무슨 오브젝트인지 판별하고 싶다
// 텍스트를 마우스 커서 위에 띄우고 싶다
// 텍스트를 TimelineObjectListBase에 끌어다 놓을 때 
// 좌클릭 해제시 objectInfo를 파괴하기전에 BoxCollider를 키고 싶다



public class ObjectCheck : MonoBehaviour
{
    public static ObjectCheck instance;

    public GameObject objectInfoFactory;
    GameObject objectInfo;
    // 생성할 수 있는 상태인지
    bool instantiateOk = true;
    public Transform canvas;
    public RaycastHit hitInfo;

    //public Text objectInfoText;
    public string saveName;

    // 저장할 수 있는 상태인지
    bool isSave = true;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 오브젝트 판별
        DistinctObject();
        ObjectInfoMove();
    }

    public void DistinctObject()
    {
        // 마우스 좌클릭하면
        if (Input.GetButton("Fire1"))
        {
            // 레이를 쏜다
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hitInfo;
            // 오브젝트 판별한다
            if (Physics.Raycast(ray, out hitInfo))
            {
                if(isSave == true)
                {
                    saveName = hitInfo.transform.name;
                    isSave = false;
                }
                // 말풍선을 마우스 커서 위에 띄우고 싶다
                if (instantiateOk == true)
                {
                    objectInfo = Instantiate(objectInfoFactory, canvas);
                    objectInfo.transform.position = Input.mousePosition;
                    instantiateOk = false;
                }

            }
        }
    }

    public void ObjectInfoMove()
    {
        if(objectInfo != null)
        {
            objectInfo.transform.position = Input.mousePosition;
            if (Input.GetButtonUp("Fire1"))
            {
                if (SubLineManager.instance.results.Count > 0)
                {
                    if (SubLineManager.instance.results[0].gameObject.name == "ObjectViewport" || SubLineManager.instance.results[0].gameObject.name == "ObjectList(Clone)")
                    {
                        AddList.instance.AddObjectList();
                        Destroy(objectInfo);
                        instantiateOk = true;
                        isSave = true;
                    }
                }
                else
                {
                    Destroy(objectInfo);
                    instantiateOk = true;
                    isSave = true;
                }
            }
        }
    }
}
