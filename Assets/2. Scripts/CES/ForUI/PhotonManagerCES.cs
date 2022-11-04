using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManagerCES : MonoBehaviourPun
{
    public Transform fanSpawnPos;
    public Transform artistSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    PhotonNetwork.Instantiate("Player_VoiceTest", artistSpawnPos.position, Quaternion.identity);
        //}
        //PhotonNetwork.Instantiate("Player_VoiceTest", fanSpawnPos.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
