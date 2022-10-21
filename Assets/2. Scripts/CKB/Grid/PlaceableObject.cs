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

    Vector3[] vertices;

    void Start()
    {
        InitializeColliderVertexLocalPositions();
        CalculateSizeInCells();
    }

    void InitializeColliderVertexLocalPositions()
    {
        BoxCollider bCol = GetComponent<BoxCollider>();

        vertices = new Vector3[4];

        vertices[0] = bCol.center + new Vector3(-bCol.size.x, -bCol.size.y, -bCol.size.z) * 0.5f;
        vertices[1] = bCol.center + new Vector3(bCol.size.x, -bCol.size.y, -bCol.size.z) * 0.5f;
        vertices[2] = bCol.center + new Vector3(bCol.size.x, -bCol.size.y, bCol.size.z) * 0.5f;
        vertices[3] = bCol.center + new Vector3(-bCol.size.x, -bCol.size.y, bCol.size.z) * 0.5f;
    }

    void CalculateSizeInCells()
    {
        Vector3Int[] t_vertices = new Vector3Int[vertices.Length];

        for (int i = 0; i < t_vertices.Length; ++i)
        {
            Vector3 worldPos = transform.TransformPoint(vertices[i]);
            t_vertices[i] = BuildingSystem.Instance.GetCellPosition(worldPos);
        }

        size = new Vector3Int(Mathf.Abs((t_vertices[0] - t_vertices[1]).x), Mathf.Abs((t_vertices[0] - t_vertices[3]).y), 1);
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
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

        Vector3[] t_vertices = new Vector3[vertices.Length];

        for (int i = 0; i < t_vertices.Length; ++i)
            t_vertices[i] = vertices[(i + 1) % vertices.Length];

        vertices = t_vertices;
    }
}
