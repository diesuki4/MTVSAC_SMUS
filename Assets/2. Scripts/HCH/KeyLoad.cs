using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// keybar와 같은 프레임의 key가 있다면 그 key의 정보를 불러오고 싶다

public class KeyLoad : MonoBehaviour
{
    TimelineKey tk;
    GameObject keyBar;
    KeyBarMove kbm;
    // Start is called before the first frame update
    void Start()
    {
        tk = this.GetComponent<TimelineKey>();
        keyBar = GameObject.Find("KeyBar");
        kbm = keyBar.GetComponent<KeyBarMove>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadKeyInfo();
    }

    // keybar와 같은 프레임의 key가 있다면 그 key의 정보를 불러오고 싶다
    public void LoadKeyInfo()
    {
        // keybar와 같은 프레임의 key가 있다면
        if(tk.frame == kbm.frame)
        {
            //그 key의 정보를 불러오고 싶다
            this.transform.position = tk.position;
            this.transform.rotation = tk.rotation;

        }
    }
}
