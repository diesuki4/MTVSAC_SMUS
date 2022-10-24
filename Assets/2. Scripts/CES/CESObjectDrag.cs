using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Utility;

public class CESObjectDrag : MonoBehaviour
{
    Vector3 offset;

    void OnMouseDown()
    {
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit))
            offset = transform.position - hit.point;

        CESBuildingSystem.Instance.objectToPlace = GetComponent<CESPlaceableObject>();
    }

    void OnMouseUp()
    {
        
    }

    void OnMouseDrag()
    {
        Vector3 pos = offset;
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit))
            pos += hit.point;

        transform.position = CESBuildingSystem.Instance.SnapCoordinateToGrid(pos);

        CESBuildingSystem.Instance.RevalidateGrid();
    }
}
