using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTest : MonoBehaviour
{
    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) SelectObject();

        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.blue);
        }
    }

    private void SelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,100, 1 << LayerMask.NameToLayer("Object")))
        {
            string objectName = hit.collider.gameObject.name;
            print(objectName);

            BlockMove block = hit.transform.GetComponent<BlockMove>();
            if (block == null) return;

            block.selected = !block.selected;
            Debug.Log(block.selected);
        }
    }
}
