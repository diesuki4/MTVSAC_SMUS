using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;

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
        TimelineObject tl_object = BuildingSystem.Instance.getTimelineObject(guid);

        position = tl_object.transform.position;
        rotation = tl_object.transform.rotation;
        active = tl_object.isActive;
    }

    public void SetKeyInfo(string guid, TL_Types.Key key)
    {
        this.guid = guid;
        this.frame = key.frame;

        position = key.position;
        rotation = key.rotation;
        active = key.active;
    }
}
