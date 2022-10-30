using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterLikeAnim : MonoBehaviour
{
    public void PlayMotion()
    {
        foreach (Transform tr in transform)
            tr.GetComponent<Animator>().SetTrigger("Play");
    }
}
