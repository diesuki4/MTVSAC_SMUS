using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Box
{
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public float minZ;
    public float maxZ;
}

public class PlaceableObject : MonoBehaviour
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public bool isPlaced;
    public bool isActive;
    [HideInInspector]
    public Vector3Int size;

    Vector3[] l_vertices;
    Transform floor;
    Renderer[] renderers;

    void Awake()
    {
        InitializeColliderVertexLocalPositions();
        CalculateSizeInCells();

        floor = GameObject.Find("Floor").transform;
    }

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();

        isActive = true;
    }

    void Update()
    {
        foreach (Renderer rend in renderers)
            rend.enabled = isActive;
    }

    void InitializeColliderVertexLocalPositions()
    {
        BoxCollider bCol = GetComponent<BoxCollider>();

        l_vertices = new Vector3[4];

        l_vertices[0] = bCol.center + new Vector3(-bCol.size.x, -bCol.size.y, -bCol.size.z) * 0.5f;
        l_vertices[1] = bCol.center + new Vector3(bCol.size.x, -bCol.size.y, -bCol.size.z) * 0.5f;
        l_vertices[2] = bCol.center + new Vector3(bCol.size.x, -bCol.size.y, bCol.size.z) * 0.5f;
        l_vertices[3] = bCol.center + new Vector3(-bCol.size.x, -bCol.size.y, bCol.size.z) * 0.5f;
    }

    void CalculateSizeInCells()
    {
        Vector3Int[] vertices = new Vector3Int[l_vertices.Length];

        for (int i = 0; i < vertices.Length; ++i)
        {
            Vector3 worldPos = transform.TransformPoint(l_vertices[i]);
            vertices[i] = BuildingSystem.Instance.GetCellPosition(worldPos);
        }

        size = new Vector3Int(Mathf.Abs((vertices[0] - vertices[1]).x), Mathf.Abs((vertices[0] - vertices[3]).y), 1);
    }

    public Box GetBox()
    {
        Box box = new Box();
        BoxCollider bCol = GetComponent<BoxCollider>();

        box.minX = transform.TransformPoint(bCol.center).x - bCol.bounds.size.x * 0.5f;
        box.maxX = transform.TransformPoint(bCol.center).x + bCol.bounds.size.x * 0.5f;

        box.minY = transform.TransformPoint(bCol.center).y - bCol.bounds.size.y * 0.5f;
        box.maxY = transform.TransformPoint(bCol.center).y + bCol.bounds.size.y * 0.5f;

        box.minZ = transform.TransformPoint(bCol.center).z - bCol.bounds.size.z * 0.5f;
        box.maxZ = transform.TransformPoint(bCol.center).z + bCol.bounds.size.z * 0.5f;

        return box;
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(l_vertices[0]);
    }

    public void Move(MoveDirection moveDirection)
    {
        Vector3 originPos = transform.position;
        Vector3 dir = Vector3.zero;
        float cellWidth = BuildingSystem.Instance.mainTilemap.cellSize.x;

        switch (moveDirection)
        {
            case MoveDirection.Up :
                dir = Vector3.forward;
                break;
            case MoveDirection.Down :
                dir = Vector3.back;
                break;
            case MoveDirection.Right :
                dir = Vector3.right;
                break;
            case MoveDirection.Left :
                dir = Vector3.left;
                break;
        }

        transform.position += dir * cellWidth;

        BuildingSystem.Instance.ClearGrid(this);

        if (isTransformable() == false || BuildingSystem.Instance.isOverlapped(this))
            transform.position = originPos;
        
        BuildingSystem.Instance.ClearGrid();
    }

    public void VerticalMove(float sw)
    {
        if (sw == 0 || gameObject.layer == LayerMask.NameToLayer("Selected"))
            return;

        float cellWidth = BuildingSystem.Instance.mainTilemap.cellSize.x;
        float deltaY = cellWidth * sw * 10f;

        gameObject.layer = LayerMask.NameToLayer("Selected");

        if (isGrounded() == false || (isGrounded() && 0 < sw))
            transform.position += Vector3.up * deltaY;

        gameObject.layer = LayerMask.NameToLayer("Floor");
    }

    bool isGrounded()
    {
        float cellWidth = BuildingSystem.Instance.mainTilemap.cellSize.x;

        float rayDistance = 2.5f;
        float rayFrom = 0.5f;

        foreach (Vector3 l_vertex in l_vertices)
        {
            Vector3 vertex = transform.TransformPoint(l_vertex);

            Ray ray = new Ray(vertex + Vector3.up * rayFrom, Vector3.down);

            if (Physics.Raycast(ray, rayDistance, 1 << LayerMask.NameToLayer("Floor")))
                return true;
        }

        return false;
    }

    public void Rotate(float degree = 90)
    {
        Quaternion originRot = transform.rotation;
        Vector3Int originSize = size;

        Vector3[] oringinLocalVertices = new Vector3[4];
        Array.Copy(l_vertices, oringinLocalVertices, l_vertices.Length);

        transform.Rotate(0, degree, 0);
        size = new Vector3Int(size.y, size.x, 1);

        Vector3[] vertices = new Vector3[l_vertices.Length];

        for (int i = 0; i < vertices.Length; ++i)
            vertices[i] = l_vertices[(i + 1) % l_vertices.Length];

        l_vertices = vertices;

        BuildingSystem.Instance.ClearGrid(this);

        if (isTransformable() == false || BuildingSystem.Instance.isOverlapped(this))
        {
            transform.rotation = originRot;
            size = originSize;
            Array.Copy(oringinLocalVertices, l_vertices, l_vertices.Length);
        }

        BuildingSystem.Instance.ClearGrid();
    }

    public bool isTransformable()
    {
        float rayDistance = 1000;
        float rayFrom = 0.5f;

        foreach (Vector3 l_vertex in l_vertices)
        {
            Ray ray = new Ray(transform.TransformPoint(l_vertex) + Vector3.up * rayFrom, Vector3.down);

            if (Physics.Raycast(ray, rayDistance, 1 << LayerMask.NameToLayer("Floor")) == false)
                return false;
        }

        return true;
    }
}
