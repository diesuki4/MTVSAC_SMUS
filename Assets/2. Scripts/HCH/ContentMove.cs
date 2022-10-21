using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentMove : MonoBehaviour
{
    public GameObject objectContent;
    public GameObject timerContent;
    RectTransform objectRT;
    RectTransform timerRT;

    // Start is called before the first frame update
    void Start()
    {
        objectRT = objectContent.GetComponent<RectTransform>();
        timerRT = timerContent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // content 길이를 둘이 항상 같게 하고 싶다
        Rect objectHeight = objectRT.rect;
        Rect timerHeight = timerRT.rect;
        timerHeight.height = objectHeight.height;
        //timerRT.rect.height = timerHeight;
        print(objectHeight.height);
        print(timerHeight.height);
        timerHeight.height += 50;

        //Vector3 objectPos = objectContent.transform.position;
        //Vector3 timerPos = timerContent.transform.position;
        //objectPos.y = timerPos.y;
        //timerContent.transform.position = timerPos;
    }
}
