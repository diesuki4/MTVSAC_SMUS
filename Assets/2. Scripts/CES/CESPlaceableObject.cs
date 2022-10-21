using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CESPlaceableObject : MonoBehaviour
{
    public bool isPlaced;
    public Vector3Int size;

    Vector3[] vertices;

    void Start()
    {
        GetColliderVertexLocalPositions();
        CalculateSizeInCells();
    }

    public void Place()
    {
        Destroy(GetComponent<CESObjectDrag>());

        isPlaced = true;
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        size = new Vector3Int(size.y, size.x, 1);

        Vector3[] t_vertices = new Vector3[vertices.Length];

        for (int i = 0; i < t_vertices.Length; ++i)
            t_vertices[i] = vertices[(i + 1) % vertices.Length];

        vertices = t_vertices;
    }

    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(vertices[0]);
    }

    void GetColliderVertexLocalPositions()
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
            t_vertices[i] = CESBuildingSystem.Instance.gridLayout.WorldToCell(worldPos);
        }

        size = new Vector3Int(Mathf.Abs((t_vertices[0] - t_vertices[1]).x), Mathf.Abs((t_vertices[0] - t_vertices[3]).y), 1);
    }
}
