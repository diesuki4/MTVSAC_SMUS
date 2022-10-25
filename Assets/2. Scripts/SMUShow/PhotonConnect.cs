using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    public byte maxPlayers;
    public string roomName;
    public string nextScene;

    [ExecuteInEditMode]
    void OnValidate()
    {
        maxPlayers = (byte)Mathf.Clamp(maxPlayers, 0, 20);
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update() { }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        
        CreateRoom();
    }
    
    void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        
        roomOptions.MaxPlayers = maxPlayers;
        
        roomOptions.IsVisible = true;
    
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        
        JoinRoom();
    }

    void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        PhotonNetwork.LoadLevel(nextScene);
    }
}
