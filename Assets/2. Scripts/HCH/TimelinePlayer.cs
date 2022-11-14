using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Timeline;
using Timeline.Types;

// 저장한 타임라인을 불러오고 싶다
// 특정 버튼을 누르면 프레임에 따라 저장된 키 값(position, rotation, active)을 불러오고 싶다
public class TimelinePlayer : MonoBehaviour
{
    // const int frameSpeed = 30;

    // public void OnClickPlayKeyData()
    // {
    //     Dictionary<string, TL_Timeline> timelines = TimelineManager.Instance.GetTimelines();

    //     foreach (KeyValuePair<string, TL_Timeline> pair in timelines)
    //     {
    //         string guid = pair.Key;
    //         List<TL_Types.Key> keyList = pair.Value.GetKeys();

    //         StartCoroutine(IEPlayKeyData(guid, keyList));
    //     }
    // }

    // IEnumerator IEPlayKeyData(string guid, List<TL_Types.Key> keyList)
    // {
    //     int currentKeyNo = 0;
    //     int lastKeyNo = keyList.Count - 1;
    //     float f_frame = 0;
    //     int frame = 0;

    //     while (currentKeyNo <= lastKeyNo)
    //     {
    //         if (frame == keyList[lastKeyNo].frame)
    //         {
    //             TimelineObject tlObject = TimelineManager.Instance.GetTimelineObject(guid);

    //             tlObject.transform.position = key.position;
    //             tlObject.transform.rotation = key.rotation;
    //             foreach (Renderer rend in tlObject.GetComponentsInChildren<Renderer>())
    //                 rend.enabled = key.active;
    //         }

    //         f_frame += Time.deltaTime * frameSpeed;
    //         frame = (int)f_frame;
    //     }
    // }
}
