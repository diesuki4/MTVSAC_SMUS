using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutMousePointer : MonoBehaviour
{
    public Transform weightlessness;

    // Start is called before the first frame update
    void Start()
    {
        weightlessness.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        weightlessness.gameObject.SetActive(true);
    }
    public  void OnMouseExit()
    {
        weightlessness.gameObject.SetActive(false);
    }
}
