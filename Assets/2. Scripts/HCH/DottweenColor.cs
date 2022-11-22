using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
// 만약 그래픽 레이캐스터에 닿은 오브젝트가 자신의 자식오브젝트라면 알파값을 100으로 하고 싶다

public class DottweenColor : MonoBehaviour
{
    Image img;
    Color originColor;
    Color checkColor;
    // Start is called before the first frame update
    void Start()
    {
        img = this.GetComponent<Image>();
        originColor = img.color;
        checkColor = new Color32(174, 174, 174, 255);
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
        if (SubLineManager.instance.results[0].gameObject == this.gameObject && Input.GetButton("Fire1") == false)
        {
            // 색깔을 바꾸고 싶다
            img.DOColor(checkColor, 0.2f);
        }
        else
        {
            img.color = originColor;
        }
    }
}
