﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public bool selected = false;
    public GameObject canvas;
    //public bool checkSelected = false;

    GameObject selectOutline;

    // Start is called before the first frame update
    void Start()
    {
        selectOutline = transform.Find("Outline").gameObject;
        selectOutline.SetActive(false);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (selected == false)
        {
            selectOutline.SetActive(false);
            canvas.SetActive(false);
        }

        else if (selected == true)
        {
            selectOutline.SetActive(true);
            canvas.SetActive(true);
            GeunyangMove();
        }
    }

    void GeunyangMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        transform.position += dir * 10 * Time.deltaTime;
    }
}