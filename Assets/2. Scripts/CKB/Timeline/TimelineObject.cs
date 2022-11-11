using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Timeline;
using Timeline.Utility;
using Timeline.Types;

public class TimelineObject : MonoBehaviour
{
    public TL_ENUM_Types tlType;
    public string itemName;

    public string guid;

    public bool isActive;
    Renderer[] renderers;

    void Awake()
    {
        guid = TL_Utility.NewGuid();

        renderers = GetComponentsInChildren<Renderer>();

        isActive = true;
    }

    void Update()
    {

    }

    public void Initialize(TL_ENUM_Types tlType, string itemName, string guid, TL_Types.Key key)
    {
        this.tlType = tlType;
        this.itemName = itemName;
        this.guid = guid;

        transform.position = key.position;
        transform.rotation = key.rotation;
    }
}
