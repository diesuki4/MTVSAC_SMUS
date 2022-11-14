using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 앞으로 날라가게 하고 싶다
// 2초의 라이프사이클을 가지게 하고 싶다

public class NeonMove_Tool : MonoBehaviour
{
    public float speed = 10f;
    float currentTime;
    float lifeTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = Vector3.left * 90;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        this.transform.position += transform.parent.forward * speed * Time.deltaTime;
        if(currentTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
