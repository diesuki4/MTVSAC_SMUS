    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravity : MonoBehaviour
{
    Vector3 pos;
    float PosY;
    [Header("상하이동 폭")]
    public float width = 2;

    [Header("이동 속도")]
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        PosY = pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.y = PosY + width * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

}
