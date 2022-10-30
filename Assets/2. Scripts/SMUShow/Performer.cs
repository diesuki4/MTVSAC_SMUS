using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Photon.Pun;

public class Performer : MonoBehaviourPun
{
    public AfterLikeAnim afterLikeAnim;

    PlayableDirector pd;

    void Start()
    {
        pd = GetComponent<PlayableDirector>();
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
            if (pd.time <= Mathf.Epsilon)
                if (Input.GetKeyDown(KeyCode.R))
                    photonView.RPC("RpcStartCinemachine", RpcTarget.All);
    }

    [PunRPC]
    void RpcStartCinemachine()
    {
        pd.Play();
        afterLikeAnim.PlayMotion();
    }
}
