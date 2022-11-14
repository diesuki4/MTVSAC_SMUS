using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 네온을 시간초를 조금 다르게 해서 생성하고 싶다

public class NeonCircle : MonoBehaviour
{
    public GameObject neonCircleFactory;
    float PosY = 0;
    // Start is called before the first frame update
    void Start()
    {
        MakeNeonCircle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeNeonCircle()
    {
        // 네온을 생성할 때마다 y값을 1씩 줄이고 싶다
        for(int i = 0; i < 60; i++)
        {
            PosY += 1;
            GameObject neonCircle = Instantiate(neonCircleFactory, this.transform);
            neonCircle.transform.position = new Vector3(transform.position.x, transform.position.y - PosY, transform.position.z);
        }
    }
}
