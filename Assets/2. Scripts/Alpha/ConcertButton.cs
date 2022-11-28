﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConcertButton : MonoBehaviour
{
    public ConcertInfo concertInfo;

    public void Initialize(ConcertInfo concertInfo)
    {
        this.concertInfo = concertInfo;
    }

    public void OnClickButton()
    {
        PlayerPrefs.SetInt("concert_id", concertInfo.concert_id);
        ConcertDataManager.instance.concert_Id = concertInfo.concert_id;
        //ConcertManager.SetConcertState(concertInfo.concert_id, true);

        //SceneManager.LoadScene("Studio_Alpha_HCH");
        //SceneManager.LoadScene("Concert_Beta_HCH");
    }

}
