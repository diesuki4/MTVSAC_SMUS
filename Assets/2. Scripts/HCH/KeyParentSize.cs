using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// KeyParent의 크기는 항상 Content의 크기를 따라가게 하고 싶다

public class KeyParentSize : MonoBehaviour
{
    // keyParent의 rect transform
    RectTransform kRT;
    // content의 rect transform
    public RectTransform cRT;

    // Start is called before the first frame update
    void Start()
    {
        kRT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
