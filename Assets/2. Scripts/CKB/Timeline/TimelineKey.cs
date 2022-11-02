using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineKey : MonoBehaviour
{
    public string guid;
    public int frame;
    public Vector3 position;
    public Quaternion rotation;
    public bool active;

    public void SetKeyInfo(string guid, int frame)
    {
        this.guid = guid;
        this.frame = frame;
print(guid);
        Transform tl_transform = BuildingSystem.Instance.getTransform(guid);

        position = tl_transform.position;
        rotation = tl_transform.rotation;
        active = tl_transform.GetComponent<PlaceableObject>().isActive;
    }
}
