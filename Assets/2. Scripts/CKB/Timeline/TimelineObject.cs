using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Timeline;
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

    public void Play()
    {
        foreach (TL_Types.Key key in TimelineManager.Instance.GetTimeline(guid).GetKeys())
            StartCoroutine(IEReservateKey(key));
    }

    IEnumerator IEReservateKey(TL_Types.Key key)
    {
        int frame = 0;

        while (frame++ < key.frame)
        {
            yield return null;
            yield return null;
        }

        transform.position = key.position;
        transform.rotation = key.rotation;
        isActive = key.active;
    }
}
