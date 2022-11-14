using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 네온이 일정한 속도로 endPos까지 도착하게 하고 싶다
// 방향은 endPos쪽으로 하고 싶다
// 도착하면 파괴하고 싶다
public class NeonMove : MonoBehaviour
{
    public float speed;
    GameObject endPos;
    Vector3 dir;
    Quaternion rot;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        endPos = GameObject.Find("EndPos");
        dir = endPos.transform.position - this.transform.position;
        //rot = Quaternion.LookRotation(dir.normalized);
        angle = Vector3.Angle(this.transform.position, endPos.transform.position);
        //this.transform.rotation = angle;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
