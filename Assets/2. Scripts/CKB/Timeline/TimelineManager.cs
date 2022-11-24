using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;
using Timeline.Utility;
using Timeline.Timeline;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance;

    public ConcertData concertData;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        timelines = new Dictionary<string, TL_Timeline>();
        timelineObjects = new Dictionary<string, TimelineObject>();

        if (PlayerPrefs.HasKey("concert_id"))
        {
            int concert_id = PlayerPrefs.GetInt("concert_id");

            concertData = ConcertManager.GetConcertData(concert_id);

            timelines = TL_Utility.FromCDATA(concertData.cdata);

            Initialize();
        }
    }

    public Dictionary<string, TL_Timeline> timelines;
    
    public Dictionary<string, TimelineObject> timelineObjects;

    public TimelineObject GetTimelineObject(string guid)
    {
        if (timelineObjects.ContainsKey(guid) == false)
            return null;

        return timelineObjects[guid];
    }

    void Update() { }

    float posY = 125;

    void Initialize()
    {
        foreach (KeyValuePair<string, TL_Timeline> pair in timelines)
        {
            string guid = pair.Key;
            TL_Timeline timeline = pair.Value;

            TimelineObject tlObject = Instantiate(GetPrefab(timeline.tlType, timeline.itemName)).GetComponent<TimelineObject>();
            tlObject.Initialize(timeline.tlType, timeline.itemName, guid, timeline.GetKeys().First());
            timelineObjects.Add(guid, tlObject);
            BuildingSystem.Instance.objectList.Add(tlObject.GetComponent<PlaceableObject>());

            ObjectListName objectListName = AddList.instance.AddObjectList(guid, timeline);

            foreach (TL_Types.Key key in timeline.GetKeys().Skip(1))
                KeyManager.instance.AddObjectKey(objectListName, key, posY);

            posY -= 50;
        }

        GetComponent<TimelinePlayer>().LoadKeyData();
    }

    public bool Save()
    {
        concertData.cdata = TL_Utility.ToCDATA(timelines);

        return ConcertManager.SetConcertData(concertData);
    }

    public GameObject GetPrefab(TL_ENUM_Types tlType, string itemName)
    {
        return Resources.Load(tlType.ToString() + "/" + itemName) as GameObject;
    }

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
                return new TL_Types.Object(frame, active, tr.position, tr.rotation);
            case TL_ENUM_Types.Effect :
                return new TL_Types.Effect(frame, active, tr.position, tr.rotation);
            case TL_ENUM_Types.Light :
                return new TL_Types.Light(frame, active, tr.position, tr.rotation);
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

    public int IndexOf(string guid, int frame)
    {
        return timelines[guid].IndexOf(frame);
    }

    public bool UpdateKey(TimelineKey tlKey)
    {
        if (isTimelineExist(tlKey.guid) == false)
            return false;

        return timelines[tlKey.guid].UpdateKey(tlKey);
    }

    public Dictionary<string, TL_Timeline> GetTimelines()
    {
        return timelines;
    }
}
