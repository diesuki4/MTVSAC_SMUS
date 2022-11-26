using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
// 버튼에 마우스를 1초이상 올렸을 때 설명이 페이드인되고 내렸을때 페이드 아웃되고 싶다

public class ExplainFadeInOut : MonoBehaviour
{
    Image img;
    public GameObject buttonParent;
    FadeInOut fio;
    public Text txt;
    public float fadeInTime = 0.5f;
    public float fadeOutTime = 0.5f;

    float currentTime;
    public float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        fio = buttonParent.GetComponent<FadeInOut>();
    }

    // Update is called once per frame
    void Update()
    {
        ExplainFade();
    }

    bool bFadeInExecuted;
    bool bFadeOutExecuted;

    Tween twFadeInImg;
    Tween twFadeOutImg;
    Tween twFadeInTxt;
    Tween twFadeOutTxt;

    public void ExplainFade()
    {
        if (fio.isCheck == true)
        {
            if (bFadeInExecuted == false)
            {
                twFadeOutImg.Kill();
                twFadeOutTxt.Kill();
                twFadeInImg = img.DOFade(1, fadeInTime);
                twFadeInTxt = txt.DOFade(1, fadeInTime);
                bFadeInExecuted = true;
                bFadeOutExecuted = false; 
            }
        }
        else
        {
            if (bFadeOutExecuted == false)
            {
                twFadeInImg.Kill();
                twFadeInTxt.Kill();
                twFadeOutImg = img.DOFade(0, fadeOutTime);
                twFadeOutTxt = txt.DOFade(0, fadeOutTime);
                bFadeInExecuted = false;
                bFadeOutExecuted = true;
            }
        }
    }
}
