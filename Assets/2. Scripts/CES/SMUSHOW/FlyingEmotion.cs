using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class FlyingEmotion : MonoBehaviourPun
{
    [Header("곡률")]
    public float curvature;
    [Header("날아가는 시간")]
    public float flyTime;

    float t;

    Transform origin;
    Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        t += Time.deltaTime;

        Vector3 center = (origin.position 
            + destination.position) * 0.5f 
            - new Vector3(0, curvature, 0);
        Vector3 relOriginPos = origin.position - center;
        Vector3 relDestination = destination.position - center;

        transform.position = Vector3.Slerp(relOriginPos, relDestination, t / flyTime) + center;

        if (flyTime <= t)
            PhotonNetwork.Destroy(gameObject);
    }

    public void Initialize(Transform origin, Transform destination)
    {
        this.origin = origin;
        this.destination = destination;
    }
}
