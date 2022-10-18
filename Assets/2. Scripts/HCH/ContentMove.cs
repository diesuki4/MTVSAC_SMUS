using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentMove : MonoBehaviour
{
    public GameObject objectContent;
    public GameObject timerContent;
    Scrollbar objectSb;
    Scrollbar TimerSb;

    // Start is called before the first frame update
    void Start()
    {
        objectSb = objectContent.GetComponent<Scrollbar>();
        TimerSb = timerContent.GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        //objectSb.value = TimerSb.value;
        Vector3 objectPos = objectContent.transform.position;
        Vector3 timerPos = timerContent.transform.position;
        objectPos.y = timerPos.y;
        timerContent.transform.position = timerPos;
    }
}
