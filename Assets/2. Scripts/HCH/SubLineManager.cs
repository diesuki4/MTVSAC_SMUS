using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// KeyBar를 마우스 우클릭할 때 보조선을 생성하고 싶다

public class SubLineManager : MonoBehaviour
{
    public static SubLineManager instance;

    public GameObject sublineFactory;
    public Transform canvas;
    GraphicRaycaster gr;
    public GameObject keyBarText;

    public List<RaycastResult> results;

    public SubLineManager()
    {
        instance = this;
        results = new List<RaycastResult>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gr = canvas.GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //var ped = new PointerEventData(canvas.GetComponent<EventSystem>());
        //ped.position = Input.mousePosition;
        //results = new List<RaycastResult>();
        //gr.Raycast(ped, results);
        //if (results.Count <= 0) return;

        var ped = new PointerEventData(EventSystem.current);
        ped.position = Input.mousePosition;
        results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);

        foreach(RaycastResult hit in results)
        {
            GameObject go = hit.gameObject;
        }

        if (results.Count <= 0) return;
        print(results[0]);
        AddSubLine();
    }

    public void AddSubLine()
    {
        if (results[0].gameObject.name == keyBarText.name)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                GameObject subline = Instantiate(sublineFactory, canvas);
                subline.transform.position = new Vector2(this.transform.position.x, 215);
            }
        }
        else return;
        
    }
}
