using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;
// objectlist가 생성될 때 오브젝트의 타입에 따라 안의 아이콘을 다르게 하고 싶다

public class ObjectListIcon : MonoBehaviour
{
    public GameObject img_Object;
    public GameObject img_Effect;
    public GameObject img_Light;
    public GameObject img_Camera;
    ObjectListName oln;

    // Start is called before the first frame update
    void Start()
    {
        oln = this.GetComponent<ObjectListName>();
        img_Object.SetActive(false);
        img_Effect.SetActive(false);
        img_Light.SetActive(false);
        img_Camera.SetActive(false);

        if (oln.tlType == TL_ENUM_Types.Object)
        {
            img_Object.SetActive(true);
        }
        else if(oln.tlType == TL_ENUM_Types.Effect)
        {
            img_Effect.SetActive(true);
        }
        else if(oln.tlType == TL_ENUM_Types.Light)
        {
            img_Light.SetActive(true);
        }
        else
        {
            img_Camera.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
