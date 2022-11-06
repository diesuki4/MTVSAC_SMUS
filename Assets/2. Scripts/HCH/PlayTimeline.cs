using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 재생 버튼을 누르면 타임라인을 재생하고 싶다
// keybar를 노래시간만큼 이동시키고 싶다
public class PlayTimeline : MonoBehaviour
{
    public GameObject fileBrowser;
    AudioSource audio;
    public GameObject keyBar;
    Vector3 saveKeyBarPos;
    float keyBarSpeed;
    bool isMove = false;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        audio = fileBrowser.GetComponent<AudioSource>();
        saveKeyBarPos = keyBar.transform.position;
        keyBarSpeed = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove == true)
        {
            // 음악이 틀어져있는 동안
            // keybar를 이동시키고 싶다
            KeyBarMove();
            if (FileBrowserTest.instance.audioSource.clip.length < currentTime)
            {
                currentTime = 0;
                isMove = false;              
            }
        }
    }

    // 재생 버튼을 누르면 노래를 플레이하고
    // keybar를 이동시키고 싶다
    public void OnClickPlayTimeline()
    {
        // 재생 버튼을 누르면 노래를 플레이하고
        audio.Stop();
        audio.Play();

        // keybar를 처음 위치로 이동시키고
        keyBar.transform.position = saveKeyBarPos;
        // keybar를 이동시키고 싶다
        isMove = true;
    }

    public void KeyBarMove()
    {
        currentTime += Time.deltaTime;
        // 음악이 틀어져있는 동안
        // keybar를 이동시키고 싶다
        // 1초에 30프레임 이동하고 싶다
        keyBar.transform.position += Vector3.right * keyBarSpeed * Time.deltaTime;
    }
}
