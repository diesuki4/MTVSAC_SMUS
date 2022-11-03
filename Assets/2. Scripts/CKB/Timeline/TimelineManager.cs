using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;
using Timeline.Timeline;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

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

    public bool NewTimeline(string guid, TL_ENUM_Types tlType, string itemName)
    {
        timelines[guid] = new TL_Timeline(tlType, itemName);

        return timelines.ContainsKey(guid);
    }

    public TL_Timeline GetTimeline(string guid)
    {
        if (timelines.ContainsKey(guid))
            return timelines[guid];
        else
            return null;
    }

    public bool AddKey(string guid, int frame, bool active, Transform tr)
    {
        TL_Types.Key key;

        if (isTimelineExist(guid) == false)
            return false;
        else if ((key = GenerateKey(timelines[guid].tlType, frame, active, tr)) != null)
            return timelines[guid].AddKey(key);
        else
            return false;
    }

    TL_Types.Key GenerateKey(TL_ENUM_Types tlType, int frame, bool active, Transform tr)
    {
        switch (tlType)
        {
            case TL_ENUM_Types.Object :
                return new TL_Types.Object(frame, active, transform.position, transform.rotation);
            case TL_ENUM_Types.Effect :
                return new TL_Types.Effect(frame, active, transform.position, transform.rotation);
            case TL_ENUM_Types.Light :
                return new TL_Types.Light(frame, active, transform.position, transform.rotation);
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
