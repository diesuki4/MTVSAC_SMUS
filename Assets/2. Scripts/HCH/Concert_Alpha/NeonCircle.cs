using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 네온을 시간초를 조금 다르게 해서 생성하고 싶다

public class NeonCircle : MonoBehaviour
{
    public GameObject neonCircleFactory;
    float spawnTime;
    float currentTime;
    float PosY = 0;
    bool startSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // 랜덤한 시간마다 네온을 생성하고 싶다
        // 네온을 생성할 때마다 y값을 1씩 줄이고 싶다
        if (currentTime > spawnTime)
        {
            GameObject neonCircle = Instantiate(neonCircleFactory, this.transform);
            neonCircle.transform.position = new Vector3(this.transform.position.x, this.transform.position.y);
            currentTime = 0;
        }

    }
}
