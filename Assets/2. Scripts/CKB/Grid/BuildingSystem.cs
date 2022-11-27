using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UI.Utility;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance;

    public BuildingSystem()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        objectList = new List<PlaceableObject>();
    }

    void Awake()
    {
        gridLayout = grid = GetComponent<Grid>();
    }

    public Canvas cnvsPalette;
    public Canvas cnvsHCH;

    public Tilemap mainTilemap;
    public enum Tile
    {
        Red,
        Green,
        Transparent
    }
    public TileBase[] tiles;

    public enum Placeable
    {
        Possible    = 1 << 0,
        Overlap     = 1 << 1,
        OOB         = 1 << 2
    }

    [HideInInspector] public PlaceableObject objectToPlace;
    [HideInInspector] public List<PlaceableObject> objectList;

    GridLayout gridLayout;
    Grid grid;

    void Start() { }

    void Update()
    {
        if (objectToPlace == null)
            return;

        if (objectToPlace.GetComponent<Camera>())
            return;

        // Rotate
        if (Input.GetKeyDown(KeyCode.R))
            objectToPlace.RotateHorizontal(15);
        else if (Input.GetKeyDown(KeyCode.F))
            objectToPlace.RotateHorizontal(-15);
        else if (Input.GetKeyDown(KeyCode.T))
            objectToPlace.RotateVertical(15);
        else if (Input.GetKeyDown(KeyCode.G))
            objectToPlace.RotateVertical(-15);

        // Move
        if (Input.GetMouseButton(1) == false)
            if (Input.GetKeyDown(KeyCode.W))
                objectToPlace.Move(PlaceableObject.MoveDirection.Up);
            else if (Input.GetKeyDown(KeyCode.A))
                objectToPlace.Move(PlaceableObject.MoveDirection.Left);
            else if (Input.GetKeyDown(KeyCode.S))
                objectToPlace.Move(PlaceableObject.MoveDirection.Down);
            else if (Input.GetKeyDown(KeyCode.D))
                objectToPlace.Move(PlaceableObject.MoveDirection.Right);

        // Horizontal Move
        if (UI_Utility.GraphicRaycast(cnvsHCH, Input.mousePosition) == false &&
            UI_Utility.GraphicRaycast(cnvsPalette, Input.mousePosition) == false)
            objectToPlace.VerticalMove(Input.GetAxisRaw("Mouse ScrollWheel"));
    }

    public Vector3Int GetCellPosition(Vector3 position)
    {
        return GetComponent<Grid>().WorldToCell(position);
    }

    public Vector3 GetCellCenterPosition(Vector3 position)
    {
        return grid.GetCellCenterWorld(GetCellPosition(position));
    }

    public void AddPlaceableObject(PlaceableObject placeableObject)
    {
        if (objectList.Contains(placeableObject) == false)
            objectList.Add(placeableObject);
    }

    public void RemovePlaceableObject(PlaceableObject placeableObject)
    {
        objectList.Remove(placeableObject);
    }

    public GameObject Instantiate(GameObject prefab)
    {
        Vector3 position = GetCellCenterPosition(Vector3.zero);
        Quaternion rotation = Quaternion.identity;

        GameObject obj = Instantiate(prefab, position, rotation);
        objectToPlace = obj.GetComponent<PlaceableObject>();

        return obj;
    }

    public TileBase[] GetTiles(PlaceableObject placeableObject)
    {
        BoundsInt area = Area(placeableObject);
        List<TileBase> tiles = new List<TileBase>();

        foreach (Vector3Int vi in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(vi.x, vi.y, 0);

            tiles.Add(mainTilemap.GetTile(pos));
        }

        return tiles.ToArray();
    }

    BoundsInt Area(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();

        area.position = GetCellPosition(placeableObject.GetStartPosition());
        area.size = placeableObject.size + Vector3Int.right + Vector3Int.up;

        return area;
    }
 
    public bool isOverlapped(PlaceableObject placeableObject)
    {
        return false;

        foreach (PlaceableObject po in objectList)
            if (po != placeableObject)
                if (isIntersect(po, placeableObject))
                    return true;
  
        return false;
    }

    public bool isIntersect(PlaceableObject po1, PlaceableObject po2)
    {
        Box box1 = po1.GetBox();
        Box box2 = po2.GetBox();

        bool conditionX = (box1.minX < box2.maxX) & (box2.minX < box1.maxX);
        bool conditionY = (box1.minY < box2.maxY) & (box2.minY < box1.maxY);
        bool conditionZ = (box1.minZ < box2.maxZ) & (box2.minZ < box1.maxZ);

        return conditionX & conditionY & conditionZ;
    }

    public Placeable isPlaceable(PlaceableObject placeableObject)
    {
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")) == false
            || UI_Utility.GraphicRaycast(cnvsPalette, Input.mousePosition) || UI_Utility.GraphicRaycast(cnvsHCH, Input.mousePosition))
            return Placeable.OOB;

        if (isOverlapped(placeableObject))
            return Placeable.Overlap;

        return Placeable.Possible;
    }

    int TileToIndex(Tile tile)
    {
        return (int)tile;
    }

    public void Fill(PlaceableObject placeableObject, Tile tile)
    {
        // Vector3Int start = GetCellPosition(placeableObject.GetStartPosition());
        // Vector3Int size = placeableObject.size;

        // mainTilemap.BoxFill(start, tiles[TileToIndex(tile)],
        //                     start.x, start.y,
        //                     start.x + size.x, start.y + size.y);
    }

    public void ClearGrid(PlaceableObject except = null)
    {
        Vector3Int mapSize = mainTilemap.size;

        mainTilemap.ClearAllTiles();

        mainTilemap.size = mapSize;

        foreach (PlaceableObject placeableObject in objectList)
            if (placeableObject != except)
                Fill(placeableObject, Tile.Transparent);
    }

    public TimelineObject getTimelineObject(string guid)
    {
        foreach (PlaceableObject po in objectList)
            if (po.GetComponent<TimelineObject>().guid == guid)
                return po.GetComponent<TimelineObject>();

        return null;
    }
}
