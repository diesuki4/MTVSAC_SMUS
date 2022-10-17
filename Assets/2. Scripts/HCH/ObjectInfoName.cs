using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 텍스트에 objectInfo의 이름을 넣고 싶다
public class ObjectInfoName : MonoBehaviour
{
    Text objectInfoText;
    // Start is called before the first frame update
    void Start()
    {
        objectInfoText = this.GetComponent<Text>();
        objectInfoText.text = ObjectCheck.instance.hitInfo.transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
