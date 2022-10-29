using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDancer : MonoBehaviour
{
    // 카메라들
    public Transform[] cams = new Transform[4];
    public Transform myView;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        cams[0].transform.position = new Vector3(myView.position.x - 6, myView.position.y, myView.position.z);
        cams[1].transform.position = new Vector3(myView.position.x - 3, myView.position.y, myView.position.z);
        cams[2].transform.position = new Vector3(myView.position.x + 3, myView.position.y, myView.position.z);
        cams[3].transform.position = new Vector3(myView.position.x +6, myView.position.y, myView.position.z);

        print(target.position);
        cams[0].LookAt(target);
        cams[1].LookAt(target);
        cams[2].LookAt(target);
        cams[3].LookAt(target);

    }
}
