using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 라이트를 0.5초 간격으로 OnOff 시키고 싶다

public class LightOnOff : MonoBehaviour
{
    public GameObject lightSet;
    float OnTime = 0.5f;
    float OffTime = 0.5f;
    float currentTime;
    bool On = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(On == false)
        {
            if (currentTime > OnTime)
            {
                lightSet.SetActive(true);
                On = true;
                currentTime = 0;
            }
        }
        else
        {
            if (currentTime > OffTime)
            {
                lightSet.SetActive(false);
                On = false;
                currentTime = 0;
            }
        }
    }
}
