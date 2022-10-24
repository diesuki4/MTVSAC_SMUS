using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;
using Timeline.Timeline;
using Timeline.Utility;

public class TimelineManager : MonoBehaviour
{
    Dictionary<string, TL_Timeline> timelines;
    
    void Start()
    {
        timelines = new Dictionary<string, TL_Timeline>();
    }

    void Update() { }

    public bool isTimelineExist(string guid)
    {
        return timelines.ContainsKey(guid);
    }

    public string NewTimeline(TL_ENUM_Types tlType, int itemIdx)
    {
        string newGuid = TL_Utility.NewGuid();

        timelines[newGuid] = new TL_Timeline(tlType, itemIdx);

        return newGuid;
    }

    public bool AddKey(string guid, TL_Types.Key key)
    {
        if (isTimelineExist(guid) == false)
            return false;

        return timelines[guid].AddKey(key);
    }

    public bool DeleteKey(string guid, TL_Types.Key key)
    {        
        if (isTimelineExist(guid) == false)
            return false;

        return timelines[guid].DeleteKey(key);
    }

    public bool DeleteKey(string guid, int frame)
    {
        if (isTimelineExist(guid) == false)
            return false;

        return timelines[guid].DeleteKey(frame);
    }
}
