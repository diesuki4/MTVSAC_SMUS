using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBlock : MonoBehaviour
{
    static SelectBlock instance = null;
    public static SelectBlock Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<SelectBlock>();
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
