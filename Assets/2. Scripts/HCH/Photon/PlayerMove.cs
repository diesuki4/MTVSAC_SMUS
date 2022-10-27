using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun
{
    float speed = 5;
    Animator anim;
    CharacterController cc;
    public GameObject player;

    //중력
    public float gravity = -9.81f;
    //점프파워
    public float jumpPower = 5;
    //y방향 속력
    float yVelocity;

    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        anim = player.GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (photonView.IsMine)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Vector3 dir = h * transform.right + v * transform.forward;
            dir.Normalize();
            //photonView.RPC("RpcForward", RpcTarget.All, dir);

            //만약에 바닥에 닿아있다면 yVelocity를 0으로 하자
            if (cc.isGrounded)
            {
                yVelocity = 0;
            }

            //만약에 스페이바(Jump)를 누르면
            if (Input.GetButtonDown("Jump"))
            {
                //yVelocity에 jumpPower를 셋팅
                yVelocity = jumpPower;
            }

            // q누르면 중력 증가
            if (Input.GetKey(KeyCode.Q))
            {
                gravity += -3f * Time.deltaTime;
            }
            // e누르면 중력 감소
            if (Input.GetKey(KeyCode.E))
            {
                gravity -= -3f * Time.deltaTime;
            }

            //yVelocity값을 중력으로 감소시킨다.
            yVelocity += gravity * Time.deltaTime;

            //dir.y에 yVelocity값을 셋팅
            dir.y = yVelocity;

            //3. 그 방향으로 움직이자.
            //P = P0 + vt
            cc.Move(dir * speed * Time.deltaTime);

            //만약에 움직인다면
            if (h != 0 || v != 0)
            {
                //상태를 Move로
                playerState.ChangeState(PlayerState.State.Walk);
            }
            //그렇지 않다면
            else
            {
                //상태를 Idle로
                playerState.ChangeState(PlayerState.State.Idle);
            }
        }
    }
    //[PunRPC]
    //public void RpcForward(Quaternion dir)
    //{
    //    player.transform.rotation = dir;
    //}
}
