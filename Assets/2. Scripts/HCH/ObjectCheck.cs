using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 마우스 좌클릭 상태일 때 레이를 쏴서 무슨 오브젝트인지 판별하고 싶다
// 말풍선을 마우스 커서 위에 띄우고 싶다

public class ObjectCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌클릭하면
        if (Input.GetButton("Fire1"))
        {
           
        }
        // 레이를 쏜다
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            print(hitInfo.transform.name);
        }
        else
        {
           
        }
        print("X");
        // 오브젝트 판별한다
    }
}
