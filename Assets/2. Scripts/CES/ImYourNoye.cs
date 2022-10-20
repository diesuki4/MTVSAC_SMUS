using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImYourNoye : MonoBehaviour
{
    public GameObject cube;
    GameObject parent;
    bool amIRot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        parent = cube.transform.parent.gameObject;
        transform.position = cube.transform.position + new Vector3(1.5f, 0, 0);

        if (amIRot)
        {
            //cube.transform.rotation = Quaternion.Lerp(cube.transform.rotation.y, cube.transform.rotation.y + 90, Time.deltaTime * 10);
        }

    }

    public void RotationCube()
    {
        cube.transform.Rotate(0.0f, 90.0f, 0.0f);
        //amIRot = true;

    }

    public void RemoveCube()
    {
        Destroy(parent);
    }
}
