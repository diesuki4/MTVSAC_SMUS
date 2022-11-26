using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
// 만약 그래픽 레이캐스터에 닿은 오브젝트가 자신의 자식오브젝트라면 알파값을 100으로 하고 싶다

public class FadeInOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image img;
    Color originColor;
    public float AlphaPer = 0.4f;
    public bool isCheck;

    // // Start is called before the first frame update
    // void Awake()
    // {
    //     img = this.GetComponent<Image>();
    //     originColor = img.color;
    //     isCheck = false;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (SubLineManager.instance.results.Count > 0)
    //     {
    //         RayCheck();
    //     }
    //     else
    //     {
    //         ;//img.color = originColor;
    //     }
    // }

    // public void RayCheck()
    // {
    //     // 만약 그래픽 레이캐스터에 닿은 오브젝트가 자신이라면
    //     if (SubLineManager.instance.results[0].gameObject == this.gameObject)
    //     {
    //         if (isCheck == false)
    //         {
    //             // 알파값을 100으로 하고 싶다
    //             originColor = img.color;
    //             img.DOFade(AlphaPer, 0.2f);
    //             isCheck = true;
    //         }
    //     }
    //     else
    //     {
    //         img.color = originColor;
    //         isCheck = false;
    //     }
    // }

    Tween tween;
    public Color o_color;

    void Awake()
    {
        img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isCheck = true;
        o_color = img.color;
        tween = img.DOFade(AlphaPer, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCheck = false;
        tween.Kill();
        img.color = o_color;
    }
}
