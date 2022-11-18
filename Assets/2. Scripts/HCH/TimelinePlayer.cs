using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Timeline;
using Timeline.Types;

// 저장한 타임라인을 불러오고 싶다
// 특정 버튼을 누르면 프레임에 따라 저장된 키 값(position, rotation, active)을 불러오고 싶다
public class TimelinePlayer : MonoBehaviour
{
    Dictionary<string, TL_Timeline> timelines;

    bool isPlaying;
    const int frameSpeed = 30;
    float fFrame;
    int frame;

    void Update()
    {
        if (isPlaying)
        {
            fFrame += Time.deltaTime * frameSpeed;
            frame = (int)fFrame;

            PlayKeyData();
        }
    }

    public void PlayKeyData()
    {
        foreach (KeyValuePair<string, TL_Timeline> pair in timelines)
        {
            string guid = pair.Key;
            List<TL_Types.Key> keyList = pair.Value.GetKeys();

            foreach (TL_Types.Key key in keyList)
            {
                if (key.frame == frame)
                {
                    TimelineObject tlObject = TimelineManager.Instance.GetTimelineObject(guid);

                    tlObject.transform.position = key.position;
                    tlObject.transform.rotation = key.rotation;
                    foreach (Renderer rend in tlObject.GetComponentsInChildren<Renderer>())
                        rend.enabled = key.active;
                }
            }
        }
    }

    public void LoadKeyData()
    {
        timelines = TimelineManager.Instance.GetTimelines();
    }

    public void OnClickPlayKeyData()
    {
        isPlaying = true;
    }
}
