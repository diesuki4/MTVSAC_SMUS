using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Utility;
using Timeline.Types;

public class TimelineObject : MonoBehaviour
{
    public TL_ENUM_Types tlType;
    public string itemName;

    [HideInInspector] public string guid;

    public bool isActive;
    Renderer[] renderers;

    void Start()
    {
        guid = TL_Utility.NewGuid();

        renderers = GetComponentsInChildren<Renderer>();

        isActive = true;
    }

    void Update()
    {
        foreach (Renderer rend in renderers)
            rend.enabled = isActive;
    }
}
