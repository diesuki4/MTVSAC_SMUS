using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSMUS : MonoBehaviour
{
    Transform endPos;
    public float turnSpeed = 500;
    public float moveSpeed = 5;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        endPos = GameObject.Find("EndPos").transform;
        dir = endPos.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, endPos.position, moveSpeed * Time.deltaTime);
        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime * 10);
    }
}
