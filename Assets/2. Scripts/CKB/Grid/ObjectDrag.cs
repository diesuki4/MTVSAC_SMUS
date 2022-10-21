using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Utility;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;

    PlaceableObject placeableObject;

    void Start()
    {
        placeableObject = GetComponent<PlaceableObject>();
    }

    void OnMouseDown()
    {
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit))
            offset = transform.position - hit.point;

        BuildingSystem.Instance.objectToPlace = placeableObject;
    }

    void OnMouseDrag()
    {
        Vector3 position = offset;
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit))
            position += hit.point;

        transform.position = BuildingSystem.Instance.GetCellCenterPosition(position);

        BuildingSystem.Instance.ClearGrid();

        if (BuildingSystem.Instance.isPlaceable(placeableObject))
            BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Green);
        else
            BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Red);
    }

    void OnMouseUp()
    {
        BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Transparent);
        BuildingSystem.Instance.AddPlaceableObject(placeableObject);
    }
}
