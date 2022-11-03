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
        TL_Timeline tl_timeline = TimelineManager.Instance.GetTimeline(guid);
        List<TL_Types.Key> list;

        foreach (TL_Types.Key key in tl_timeline.GetKeys())
        {
            switch (tl_timeline.tlType)
            {
                case TL_ENUM_Types.Object :
                    StartCoroutine(IEReservateKey((TL_Types.Object)key));
                    break;
                case TL_ENUM_Types.Effect :
                    StartCoroutine(IEReservateKey((TL_Types.Effect)key));
                    break;
                case TL_ENUM_Types.Light :
                    StartCoroutine(IEReservateKey((TL_Types.Light)key));
                    break;
            }
        }
    }

    IEnumerator IEReservateKey(TL_Types.Key tl_key)
    {
        int frame = 0;

        while (frame++ < tl_key.frame)
        {
            yield return null;
            yield return null;
        }

        transform.position = tl_key.position;
        transform.rotation = tl_key.rotation;
        isActive = tl_key.active;
    }

    IEnumerator IEReservateKey(TL_Types.Object tl_object)
    {
        yield return StartCoroutine(IEReservateKey((TL_Types.Key)tl_object));
    }

    IEnumerator IEReservateKey(TL_Types.Effect tl_effect)
    {
        yield return StartCoroutine(IEReservateKey((TL_Types.Key)tl_effect));
    }

    IEnumerator IEReservateKey(TL_Types.Light tl_light)
    {
        yield return StartCoroutine(IEReservateKey((TL_Types.Key)tl_light));
    }
}
