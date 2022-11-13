using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(CharacterController))]

public class CESPlayerMove : MonoBehaviourPun
{
    CharacterController cc;

    PlayerState playerState;

    public float moveSpeed = 10.0f;
    Vector3 dir;

    // 점프 관련 
    public float gravity = -50.0f;
    public float jumpPower = 30.0f;
    public Transform rayPos;


    // Start is called before the first frame update
    void Start()
    {
        cc = transform.GetComponent<CharacterController>();
        playerState = transform.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        SetGravity();
        PlayerMove();
    }

    void SetGravity()
    {
        if (PutMousePointer.instance.isWeightlessness == true)
        {
            gravity = -10f;
        }
        else
        {
            gravity = -30f;
        }
    }

    void PlayerMove()
    {

        transform.forward = Camera.main.transform.forward;

        if (OnTheGround())
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            dir = new Vector3(h, 0, v);
            dir.Normalize();
            //anim.SetFloat("Speed", dir.magnitude);

            dir *= moveSpeed;

            // 점프
            if (Input.GetButtonDown("Jump"))
            {
                dir.y = jumpPower;
            }
        }
        dir.y += gravity * Time.deltaTime;

        cc.Move(dir * Time.deltaTime);
    }

    // 땅 확인
    bool OnTheGround()
    {
        Ray ray = new Ray(rayPos.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
