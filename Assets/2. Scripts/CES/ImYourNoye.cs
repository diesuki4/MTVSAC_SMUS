using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImYourNoye : MonoBehaviour
{
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cube.transform.position + new Vector3(1.5f, 0, 0);
    }

    public void CubeRotation()
    {
        cube.transform.Rotate(0.0f, 90.0f , 0.0f);
    }
}
