using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public GameObject timelineLoader;
    TimelinePlayer tp;
    // Start is called before the first frame update
    void Start()
    {
        tp = timelineLoader.GetComponent<TimelinePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            tp.OnClickPlayKeyData();
        }

    }
}
