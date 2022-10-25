using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineKey : MonoBehaviour
{
    public string guid;
    public int frame;

    void SetKeyInfo(string guid, int frame)
    {
        this.guid = guid;
        this.frame = frame;
    }
}
