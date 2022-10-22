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

    [HideInInspector]
    public Vector3Int size;

    Vector3[] l_vertices;

    void Start()
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
            Vector3Int cellPos = BuildingSystem.Instance.GetCellPosition(worldPos);

            // float cellPosX = transform.InverseTransformPoint(cellPos).x;
            // float vertexX = l_vertices[i].x;

            // float cellPosY = transform.InverseTransformPoint(cellPos).y;
            // float vertexY = l_vertices[i].y;

            // if (0 < cellPosX && cellPosX < vertexX)
            //     cellPos += Vector3Int.right;

            // if (cellPosY < 0 && vertexY < cellPosY)
            //     cellPos += Vector3Int.down;

            vertices[i] = cellPos;
        }

        size = new Vector3Int(Mathf.Abs((vertices[0] - vertices[1]).x), Mathf.Abs((vertices[0] - vertices[3]).y), 0);
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(l_vertices[0]);
    }

    public void Move(MoveDirection moveDirection)
    {
        Vector3 dir = Vector3.zero;

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

        transform.position += dir;
    }

    public void Rotate(float degree)
    {
        transform.Rotate(0, degree, 0);
        size = new Vector3Int(size.y, size.x, 1);

        Vector3[] vertices = new Vector3[l_vertices.Length];

        for (int i = 0; i < vertices.Length; ++i)
            vertices[i] = l_vertices[(i + 1) % l_vertices.Length];

        l_vertices = vertices;
    }
}
