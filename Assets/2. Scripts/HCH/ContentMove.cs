using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentMove : MonoBehaviour
{
    public GameObject objectContent;
    public GameObject TimerContent;
    Scrollbar objectSb;
    Scrollbar TimerSb;

    // Start is called before the first frame update
    void Start()
    {
        objectSb = objectContent.GetComponent<Scrollbar>();
        TimerSb = TimerContent.GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        objectSb.value = TimerSb.value;
    }
}
