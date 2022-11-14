using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 네온을 시간초를 조금 다르게 해서 생성하고 싶다

public class NeonCircle_Tool : MonoBehaviour
{
    public GameObject neonCircleFactory;
    float PosY = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeNeonCircle()
    {
        // 네온을 생성할 때마다 y값을 1씩 줄이고 싶다
        for(int i = 0; i < 15; i++)
        {
            GameObject neonCircle = Instantiate(neonCircleFactory, this.transform);
            neonCircle.transform.localPosition = new Vector3(5, PosY++, 0);
        }
    }

    private void OnEnable()
    {
        MakeNeonCircle();
    }
}
