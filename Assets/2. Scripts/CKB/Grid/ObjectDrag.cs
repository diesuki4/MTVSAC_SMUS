using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Utility;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;
    Vector3 originPos;

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
        originPos = transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 position = offset;
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")))
            position += hit.point;

        transform.position = BuildingSystem.Instance.GetCellCenterPosition(position);

        BuildingSystem.Instance.ClearGrid(placeableObject);

        switch (BuildingSystem.Instance.isPlaceable(placeableObject))
        {
            case BuildingSystem.Placeable.Possible :
                BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Green);
                break;
            case BuildingSystem.Placeable.Overlap :
                BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Red);
                break;
            case BuildingSystem.Placeable.OOB :
                transform.position = originPos;
                BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Green);
                break;
        }
    }

    public void MouseDrag()
    {
        OnMouseDrag();
    }

    void OnMouseUp()
    {
        switch (BuildingSystem.Instance.isPlaceable(placeableObject))
        {
            case BuildingSystem.Placeable.Possible :
                BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Transparent);
                BuildingSystem.Instance.AddPlaceableObject(placeableObject);
                placeableObject.isPlaced = true;
                break;
            case BuildingSystem.Placeable.Overlap :
                transform.position = originPos;
                BuildingSystem.Instance.objectToPlace = null;
                BuildingSystem.Instance.ClearGrid();
                break;
            case BuildingSystem.Placeable.OOB :
                transform.position = originPos;
                BuildingSystem.Instance.objectToPlace = null;
                BuildingSystem.Instance.ClearGrid();
                break;
        }
    }

    public void MouseUp()
    {
        OnMouseUp();
    }
}
