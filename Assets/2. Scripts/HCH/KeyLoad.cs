using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;

// keybar와 같은 프레임의 key가 있다면 그 key의 정보를 불러오고 싶다

public class KeyLoad : MonoBehaviour
{
    TimelineKey tk;
    GameObject keyBar;
    KeyBarMove kbm;
    GameObject target;
    TimelineObject tl_object;

    Renderer[] renderers;
    //Vector3 savePos;
    //Quaternion saveRot;
    Vector3 startPos;
    Vector3 endPos;
    Quaternion startRot;
    Quaternion endRot;

    public List<TL_Types.Key> keys;
    public int keyOrder;
    // Start is called before the first frame update
    void Start()
    {
        tk = this.GetComponent<TimelineKey>();
        keyBar = GameObject.Find("KeyBar");
        kbm = keyBar.GetComponent<KeyBarMove>();
        tl_object = BuildingSystem.Instance.getTimelineObject(tk.guid);
        renderers = tl_object.GetComponentsInChildren<Renderer>();

        //savePos = tl_object.transform.position;
        //saveRot = tl_object.transform.rotation;
        //print(savePos);
        //startPos = keys[keyOrder].position;
        //startRot = keys[keyOrder].rotation;
    }

    // Update is called once per frame
    void Update()
    {
        LoadKeyInfo();
        foreach (Renderer rend in renderers)
            rend.enabled = tl_object.isActive;

        //if (startPos != null && endPos != null)
        //{
        //    print("lerp");
        //    Vector3.Lerp(startPos, endPos, Time.deltaTime);
        //    Quaternion.Lerp(startRot, endRot, Time.deltaTime);
        //}

    }

    // keybar와 같은 프레임의 key가 있다면 그 key의 정보를 불러오고 싶다
    public void LoadKeyInfo()
    {
        // keybar와 프레임이 같다면
        if(tk.frame == kbm.frame)
        {
            // 그 key의 정보를 불러오고 싶다
            // position, rotation은 lerp로 이동하고 싶다
            keys = TimelineManager.Instance.GetTimeline(tk.guid).GetKeys();
            keyOrder = TimelineManager.Instance.GetTimeline(tk.guid).IndexOf(tk.frame);
            //startPos = keys[keyOrder].position;
            //startRot = keys[keyOrder].rotation;
            //if (keyOrder + 1 == keys.Count)
            //{
            //    endPos = keys[keyOrder].position;
            //    endRot = keys[keyOrder].rotation;
            //    print("시작 : " + startPos + " " + "끝 : " + endPos);
            //}
            //else
            //{
            //    endPos = keys[keyOrder + 1].position;
            //    endRot = keys[keyOrder + 1].rotation;
            //    print("시작 : " + startPos + " " + "끝 : " + endPos);
            //}

            tl_object.transform.position = tk.position;
            tl_object.transform.rotation = tk.rotation;
            tl_object.isActive = tk.active;
        }
    }
}
