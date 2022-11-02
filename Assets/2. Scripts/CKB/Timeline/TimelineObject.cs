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

    public void Start()
    {
        guid = TL_Utility.NewGuid();
    }
}
