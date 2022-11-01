using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UI.Utility;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        objectList = new List<PlaceableObject>();

        gridLayout = grid = GetComponent<Grid>();
    }

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
    List<PlaceableObject> objectList;

    GridLayout gridLayout;
    Grid grid;

    void Start() { }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            objectToPlace.Rotate();
        else if (Input.GetKeyDown(KeyCode.W))
            objectToPlace.Move(PlaceableObject.MoveDirection.Up);
        else if (Input.GetKeyDown(KeyCode.A))
            objectToPlace.Move(PlaceableObject.MoveDirection.Left);
        else if (Input.GetKeyDown(KeyCode.S))
            objectToPlace.Move(PlaceableObject.MoveDirection.Down);
        else if (Input.GetKeyDown(KeyCode.D))
            objectToPlace.Move(PlaceableObject.MoveDirection.Right);
    }

    public Vector3Int GetCellPosition(Vector3 position)
    {
        return gridLayout.WorldToCell(position);
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

        print(box1.minX + ", " + box1.maxX + ", " + box1.minY + ", " + box1.maxY + ", " + box1.minZ + ", " + box1.maxZ);
        print(box2.minX + ", " + box2.maxX + ", " + box2.minY + ", " + box2.maxY + ", " + box2.minZ + ", " + box2.maxZ);

        bool conditionX = (box1.minX < box2.maxX) & (box2.minX < box1.maxX);
        bool conditionY = (box1.minY < box2.maxY) & (box2.minY < box1.maxY);
        bool conditionZ = (box1.minZ < box2.maxZ) & (box2.minZ < box1.maxZ);

        return conditionX & conditionY & conditionZ;
    }

    // public bool isOverlapped(PlaceableObject placeableObject)
    // {
    //     float boundary = 0.2f;
    //     float rayDistance = 1000;

    //     Ray ray = new Ray(placeableObject.transform.position, Vector3.down);
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit, rayDistance, 1 << LayerMask.NameToLayer("Floor")))
    //         if (Vector3.Distance(transform.position, hit.point) >= boundary)
    //             return false;

    //     foreach (TileBase tile in GetTiles(placeableObject))
    //         if (tile == tiles[TileToIndex(Tile.Transparent)] || tile == tiles[TileToIndex(Tile.Red)])
    //             return true;
            
    //     return false;
    // }

    public Placeable isPlaceable(PlaceableObject placeableObject)
    {
        RaycastHit hit;

        if (UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor")) == false)
            ;//return Placeable.OOB;

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
        Vector3Int start = GetCellPosition(placeableObject.GetStartPosition());
        Vector3Int size = placeableObject.size;

        mainTilemap.BoxFill(start, tiles[TileToIndex(tile)],
                            start.x, start.y,
                            start.x + size.x, start.y + size.y);
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
}
