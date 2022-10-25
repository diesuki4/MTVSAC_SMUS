using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [HideInInspector]
    public Vector3Int size;

    Vector3[] l_vertices;

    void Awake()
    {
        InitializeColliderVertexLocalPositions();
        CalculateSizeInCells();
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
        float rayDistance = 100;
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
