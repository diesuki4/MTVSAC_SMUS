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

    public void ExplainFade()
    {
        if (fio.isCheck == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waitTime)
            {
                img.DOFade(1, fadeInTime);
                txt.DOFade(1, fadeInTime);
            }
        }
        else
        {
            currentTime = 0;
            img.DOFade(0, fadeOutTime);
            txt.DOFade(0, fadeOutTime);
        }
    }
}
