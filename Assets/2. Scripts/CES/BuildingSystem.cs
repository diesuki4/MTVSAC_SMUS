using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GridLayout gridLayout;
    public Tilemap mainTilemap;
    public TileBase whiteTile;
    public TileBase transparentTile;
    public TileBase greenTile;
    public TileBase redTile;

    public GameObject prefab1;
    public GameObject prefab2;

    public PlaceableObject objectToPlace;
    Grid grid;

    void Start()
    {
        grid = gridLayout.GetComponent<Grid>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            InitializeWithObject(prefab1);
        else if (Input.GetKeyDown(KeyCode.B))
            InitializeWithObject(prefab2);

        if (objectToPlace == false)
            return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            objectToPlace.Rotate();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlaceAvailable(objectToPlace))
            {
                objectToPlace.Place();

                Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());

                TakeArea(start, objectToPlace.size, whiteTile);
            }
            else
            {
                //Destroy(objectToPlace.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(objectToPlace.gameObject);
        }
    }

    public Vector3 SnapCoordinateToGrid(Vector3 position)
    {
        Vector3Int cellPos = gridLayout.WorldToCell(position);

        position = grid.GetCellCenterWorld(cellPos);

        return position;
    }

    public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);

        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }

    TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        List<TileBase> tiles = new List<TileBase>();

        foreach (Vector3Int v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            tiles.Add(tilemap.GetTile(pos));
        }

        return tiles.ToArray();
    }

    bool isPlaceAvailable(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(objectToPlace.GetStartPosition());
        area.size = placeableObject.size;

        TileBase[] tileBases = GetTilesBlock(area, mainTilemap);

        foreach (TileBase tb in tileBases)
            if (tb == transparentTile)
                return false;

        return true;
    }

    public void TakeArea(Vector3Int start, Vector3Int size, TileBase tile)
    {
        mainTilemap.BoxFill(start, tile,
                                                start.x, start.y,
                                                start.x + size.x, start.y + size.y);
    }

    public void RevalidateGrid()
    {
        Vector3Int start = gridLayout.WorldToCell(objectToPlace.GetStartPosition());

        Vector3Int tilemapSize = mainTilemap.size;
        mainTilemap.ClearAllTiles();
        mainTilemap.size = tilemapSize;

        TakeArea(start, objectToPlace.size, greenTile);
    }
}
