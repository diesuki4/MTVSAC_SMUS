using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 시네머신 카메라가 돌게 하고 싶다

public class CinCamMove : MonoBehaviour
{
    public float speed;
    GameObject character;
    Vector3 point;
    bool startPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character_Big");
        point = character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(startPlay == true)
       {
            transform.RotateAround(point, Vector3.up, speed * Time.deltaTime);
       }
    }

    private void OnEnable()
    {
        startPlay = true;
    }
}
