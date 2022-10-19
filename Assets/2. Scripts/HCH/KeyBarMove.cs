using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyBarMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 savePosition;
    bool isDrag = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        // keybar를 드래그해서 x축만 이동시키고 싶다
        float XPos = Input.mousePosition.x;
        Mathf.Clamp(XPos, 0, Input.mousePosition.x);
        this.transform.position = new Vector2(Input.mousePosition.x, transform.position.y);
        savePosition = this.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}