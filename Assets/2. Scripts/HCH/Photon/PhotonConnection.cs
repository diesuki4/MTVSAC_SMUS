using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

// 연결버튼 누르면 네트워크연결 후 바로 게임씬으로 이동하고 싶다

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickConnect()
    {
        // 서버 접속 요청
        PhotonNetwork.ConnectUsingSettings();
    }

    // 마스터서버에 들어올 때 호출
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print("마스터서버 연결");
        // 로비 입장
        PhotonNetwork.JoinLobby();
    }

    // 로비 입장시 호출
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("로비 입장");
        string roomName = "Room";
        RoomOptions ro = new RoomOptions() { MaxPlayers = 2 };

        // 게임서버 입장
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }

    // 게임서버 입장시 호출
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print("게임서버 입장");
        PhotonNetwork.LoadLevel("ConcertScenePrac_HCH");
    }
}
