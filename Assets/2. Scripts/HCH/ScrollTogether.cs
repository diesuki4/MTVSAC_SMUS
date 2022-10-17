using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 타이머 스크롤뷰를 스크롤할 때 오브젝트 스크롤뷰의 y값을 같게 해주고 싶다

public class ScrollTogether : MonoBehaviour
{
    public GameObject TimerScrollBar;
    public GameObject objectScrollBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTogether()
    {
        objectScrollBar.transform.position = TimerScrollBar.transform.position;        
    }
}
