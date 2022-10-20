using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Utility;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;

    void OnMouseDown()
    {
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit))
            offset = transform.position - hit.point;
    }

    void OnMouseDrag()
    {
        Vector3 pos = offset;
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit))
            pos += hit.point;

        transform.position = BuildingSystem.Instance.SnapCoordinateToGrid(pos);
    }
}
