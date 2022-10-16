using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelItem : MonoBehaviour
{
    enum Mode
    {
        Model       = 2 << 0,
        Thumbnail   = 2 << 1
    }
    Mode mode;

    Vector3 INVALID_VECTOR3 = new Vector3(int.MinValue, int.MinValue, int.MinValue);

    public GameObject goModel;
    public GameObject goThumbnail;

    GameObject model;


    void Start()
    {
        mode = Mode.Thumbnail;
    }

    void Update() { }

    Vector3 Raycast(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue, 1 << LayerMask.NameToLayer("Floor")))
            return hit.point;
        else
            return INVALID_VECTOR3;
    }

    public void OnElementPointerDown()
    {
        if (model == null)
            model = Instantiate(goModel);

        model.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
    }

    public void OnElementDrag()
    {
        

        if (model)
            model.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
    }

    public void OnElementPointerUp()
    {
        model = null;
    }
}
