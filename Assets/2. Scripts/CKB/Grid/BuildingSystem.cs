﻿using System.Linq;
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

    [HideInInspector] public PlaceableObject objectToPlace;
    [HideInInspector] public List<PlaceableObject> objectList;
    
    GridLayout gridLayout;
    Grid grid;

    void Start() { }

    void Update() { }

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

    TileBase[] GetTiles(PlaceableObject placeableObject)
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

    public bool isPlaceable(PlaceableObject placeableObject)
    {
        foreach (TileBase tile in GetTiles(placeableObject))
            if (tile == tiles[TileToIndex(Tile.Transparent)] || tile == tiles[TileToIndex(Tile.Red)])
                return false;

        return true;
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

    public void ClearGrid(PlaceableObject except)
    {
        Vector3Int mapSize = mainTilemap.size;

        mainTilemap.ClearAllTiles();

        mainTilemap.size = mapSize;

        foreach (PlaceableObject placeableObject in objectList)
            if (placeableObject != except)
                Fill(placeableObject, Tile.Transparent);
    }
}
