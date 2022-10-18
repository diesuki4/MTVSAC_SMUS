using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// TimerList를 드래그해서 x축만 이동시키고 싶다
// TimerList의 앞부분을 드래그하면 길이를 조절할 수 있게 하고 싶다
// TimerList의 뒷부분을 드래그하면 길이를 조절할 수 있게 하고 싶다

public class TimerObjectMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 savePosition;
    bool isDrag = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("클릭시작");
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        // TimerList를 드래그해서 x축만 이동시키고 싶다
        this.transform.position = new Vector2(Input.mousePosition.x, transform.position.y);
        savePosition = this.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        Debug.Log("클릭끝");
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
