using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform viewCam;

    // Start is called before the first frame update
    void Start()
    {
        transform.forward = -viewCam.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
