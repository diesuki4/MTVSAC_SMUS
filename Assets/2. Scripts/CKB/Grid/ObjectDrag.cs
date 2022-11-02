using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Utility;

public class ObjectDrag : MonoBehaviour
{
    Vector3 offset;
    Vector3 originPos;

    PlaceableObject placeableObject;
    Outline outline;

    Color clrPlaceable = new Color(67, 236, 57, 255) / 255;
    Color clrNotPlaceable = new Color(236, 57, 84, 255) / 255;

    void Awake()
    {
        placeableObject = GetComponent<PlaceableObject>();
        outline = GetComponent<Outline>();
    }

    void OnEnable()
    {
        RaycastHit hit;

        gameObject.layer = LayerMask.NameToLayer("Selected");

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")))
        {
            transform.position = hit.point;
            offset = Vector3.zero;
        }

        BuildingSystem.Instance.objectToPlace = placeableObject;

        foreach (PlaceableObject po in BuildingSystem.Instance.objectList)
            po.GetComponent<Outline>().enabled = false;

        outline.OutlineColor = clrPlaceable;
        outline.enabled = true;
    }

    void OnMouseDown()
    {
        RaycastHit hit;

        gameObject.layer = LayerMask.NameToLayer("Selected");

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")))
            offset = transform.position - hit.point;

        BuildingSystem.Instance.objectToPlace = placeableObject;
        originPos = transform.position;

        foreach (PlaceableObject po in BuildingSystem.Instance.objectList)
            po.GetComponent<Outline>().enabled = false;

        outline.enabled = true;
    }

    void OnMouseDrag()
    {
        Vector3 position = offset;
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")))
            position += hit.point;

        Vector3 position3D = BuildingSystem.Instance.GetCellCenterPosition(hit.point);

        transform.position = new Vector3(position3D.x, hit.point.y, position3D.z);
        //transform.position = new Vector3(position3D.x, ClosestMultipleOfN(BuildingSystem.Instance.mainTilemap.cellSize.x, hit.point.y), position3D.z);
        
        BuildingSystem.Instance.ClearGrid(placeableObject);

        switch (BuildingSystem.Instance.isPlaceable(placeableObject))
        {
            case BuildingSystem.Placeable.Possible :
                BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Green);
                outline.OutlineColor = clrPlaceable;
                break;
            case BuildingSystem.Placeable.Overlap :
                BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Red);
                outline.OutlineColor = clrNotPlaceable;
                break;
            case BuildingSystem.Placeable.OOB :
                transform.position = originPos;
                BuildingSystem.Instance.Fill(placeableObject, BuildingSystem.Tile.Green);
                outline.OutlineColor = clrPlaceable;
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
                outline.OutlineColor = clrPlaceable;
                break;
            case BuildingSystem.Placeable.OOB :
                transform.position = originPos;
                BuildingSystem.Instance.objectToPlace = null;
                BuildingSystem.Instance.ClearGrid();
                outline.OutlineColor = clrPlaceable;
                break;
        }

        gameObject.layer = LayerMask.NameToLayer("Floor");
    }

    public void MouseUp()
    {
        OnMouseUp();
    }

    float ClosestMultipleOfN(float n, float x)
    {
        if (n > x)
            return n;

        x = x + n / 2;
        x = x - (x % n);

        return x;
    }
}
