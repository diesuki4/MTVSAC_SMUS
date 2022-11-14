using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 시네머신 카메라가 돌게 하고 싶다

public class NeonCircleMove : MonoBehaviour
{
    public float speed;
    GameObject character;
    Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("NeonCircleFactory_Tool");
        point = character.transform.position;
        speed = Random.Range(110, 160);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point, Vector3.up, speed * Time.deltaTime);
    }
}
