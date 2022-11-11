using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Timeline;
using Timeline.Types;

// 저장한 타임라인을 불러오고 싶다
// 특정 버튼을 누르면 프레임에 따라 저장된 키 값(position, rotation, active)을 불러오고 싶다
public class TimelinePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadKeyData()
    {
        Dictionary<string, TL_Timeline> timelines = TimelineManager.Instance.GetTimelines();

        foreach (KeyValuePair<string, TL_Timeline> pair in timelines)
        {
            string guid = pair.Key;
            TL_Timeline tlTimeline = pair.Value;
            List<TL_Types.Key> keyList =  tlTimeline.GetKeys();

            foreach (TL_Types.Key key in keyList)
            {
                //key.frame
            }
        }
    }

    public void OnClickPlayKeyData()
    {

    }
}
