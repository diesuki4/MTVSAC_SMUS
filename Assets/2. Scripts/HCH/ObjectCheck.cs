using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 마우스 좌클릭 상태일 때 레이를 쏴서 무슨 오브젝트인지 판별하고 싶다
// 말풍선을 마우스 커서 위에 띄우고 싶다

public class ObjectCheck : MonoBehaviour
{
    public static ObjectCheck instance;

    public GameObject objectInfoFactory;
    GameObject objectInfo;
    bool instantiateOk = true;
    public Transform canvas;
    public RaycastHit hitInfo;

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
                print(hitInfo.transform.name);
                // 말풍선을 마우스 커서 위에 띄우고 싶다
                if(instantiateOk == true)
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
                Destroy(objectInfo);
                instantiateOk = true;
            }
        }
    }
}
