using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerState : MonoBehaviourPun
{
    //플레이어 상태 정의
    public enum State
    {
        Idle,
        Walk,
    }

    //현재 상태
    public State curState;
    //Animator
    public Animator anim;

    public void ChangeState(State s)
    {
        //현재 상태가 s와 같다면 함수를 나간다.
        if (curState == s) return;

        //현재 상태를 s로 셋팅
        curState = s;

        //s에 따른 animation 플레이
        switch (s)
        {
            case State.Idle:
                anim.SetTrigger("Idle");
                break;
            case State.Walk:
                anim.SetTrigger("Walk");
                break;
        }
    }

    //[PunRPC]
    //public void RpcSetTrigger(string trigger)
    //{
    //    anim.SetTrigger(trigger);
    //}
}
