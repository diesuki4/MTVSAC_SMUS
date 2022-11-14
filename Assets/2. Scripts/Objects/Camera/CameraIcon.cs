using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIcon : MonoBehaviour
{
    Transform mainCam;

    void Start()
    {
        mainCam = Camera.main.transform;
    }

    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(transform.root.position);       
    }
}
