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

    public bool AddKey(string guid, int frame, Transform tr)
    {
        TL_Types.Key key;

        if (isTimelineExist(guid) == false)
            return false;
        else if ((key = GenerateKey(timelines[guid].tlType, frame, tr)) != null)
            return timelines[guid].AddKey(key);
        else
            return false;
    }

    TL_Types.Key GenerateKey(TL_ENUM_Types tlType, int frame, Transform tr)
    {
        switch (tlType)
        {
            case TL_ENUM_Types.Object :
                return new TL_Types.Object(frame, transform.position, transform.rotation);
            case TL_ENUM_Types.Effect :
                return new TL_Types.Effect(frame, transform.position, transform.rotation);
            case TL_ENUM_Types.Light :
                Light light = tr.GetComponent<Light>();
                return new TL_Types.Light(frame, transform.position, transform.rotation, light.intensity, light.color);
        }

        return null;
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

    public bool DeleteAllKeys(string guid)
    {
        if (isTimelineExist(guid) == false)
            return false;

        return timelines[guid].DeleteAllKeys();
    }
}
