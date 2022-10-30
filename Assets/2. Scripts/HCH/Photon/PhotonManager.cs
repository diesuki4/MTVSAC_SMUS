using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
// 캐릭터 생성하고 싶다
// 방장이 P버튼 누르면 공연을 시작하고 싶다

public class PhotonManager : MonoBehaviourPun
{
    public Transform spawnPos;
    public GameObject director;
    // Start is called before the first frame update
    void Start()
    {
        // 캐릭터 생성하고 싶다
        PhotonNetwork.Instantiate("Player_VoiceTest", spawnPos.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //if (PhotonNetwork.IsMasterClient)
        //{
            
        //}
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    photonView.RPC("RpcConcertStart", RpcTarget.All);
        //}
    }

    //[PunRPC]
    //public void RpcConcertStart()
    //{
    //    director.SetActive(true);
    //}
}
