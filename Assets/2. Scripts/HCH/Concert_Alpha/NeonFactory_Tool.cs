using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 일정시간마다 네온을 생성하고 싶다

public class NeonFactory_Tool : MonoBehaviour
{
    float currentTime;
    public float spawnTime;
    public GameObject neonFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnTime)
        {
            GameObject neon = Instantiate(neonFactory, transform);
            neon.transform.position = this.transform.position;
            neon.transform.forward = this.transform.forward;
            currentTime = 0;
        }
    }
}
