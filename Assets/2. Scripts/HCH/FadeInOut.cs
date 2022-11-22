using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
// 만약 그래픽 레이캐스터에 닿은 오브젝트가 자신의 자식오브젝트라면 알파값을 100으로 하고 싶다

public class FadeInOut : MonoBehaviour
{
    Image img;
    Color originColor;
    public float AlphaPer = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        originColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (SubLineManager.instance.results.Count > 0)
        {
            RayCheck();
        }
        else
        {
            img.color = originColor;
        }
    }

    public void RayCheck()
    {
        // 만약 그래픽 레이캐스터에 닿은 오브젝트가 자신이라면
        if (SubLineManager.instance.results[0].gameObject == this.gameObject)
        {
            // 알파값을 100으로 하고 싶다
            img.DOFade(AlphaPer, 0.3f);
        }
        else
        {
            img.color = originColor;
        }
    }
}
