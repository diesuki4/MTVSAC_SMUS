using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPun
{
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("Player_VoiceTest", spawnPos.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
