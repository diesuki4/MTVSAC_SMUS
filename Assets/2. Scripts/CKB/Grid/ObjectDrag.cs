using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Utility;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;

    PlaceableObject placeableObject;

    void Awake()
    {
        placeableObject = GetComponent<PlaceableObject>();
    }

    void OnEnable()
    {
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")))
        {
            transform.position = hit.point;
            offset = Vector3.zero;
        }
        
        BuildingSystem.Instance.objectToPlace = placeableObject;
    }

    void OnMouseDown()
    {
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")))
            offset = transform.position - hit.point;

        BuildingSystem.Instance.objectToPlace = placeableObject;
    }

    void OnMouseDrag()
    {
        Vector3 position = offset;
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")))
            position += hit.point;

        transform.position = BuildingSystem.Instance.GetCellCenterPosition(position);

        BuildingSystem.Instance.ClearGrid(placeableObject);

        if (BuildingSystem.Instance.isPlaceable(placeableObject))
            BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Green);
        else
            BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Red);
    }

    public void MouseDrag()
    {
        OnMouseDrag();
    }

    void OnMouseUp()
    {
        if (BuildingSystem.Instance.isPlaceable(placeableObject))
        {
            BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Transparent);
            BuildingSystem.Instance.AddPlaceableObject(placeableObject);
        }
        else
        {
            BuildingSystem.Instance.objectToPlace = null;
            BuildingSystem.Instance.RemovePlaceableObject(placeableObject);
            BuildingSystem.Instance.ClearGrid(placeableObject);
            Destroy(gameObject);
        }
    }

    public void MouseUp()
    {
        OnMouseUp();
    }
}
