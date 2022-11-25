using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Content의 PosY를 -4.3에 고정하고 싶다

public class ScrollViewFix : MonoBehaviour
{
    RectTransform rect;
    public float fixNum = -4.3f;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, fixNum);
    }
}
