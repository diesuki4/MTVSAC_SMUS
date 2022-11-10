using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 재생 버튼을 누르면 타임라인을 재생하고 싶다
// keybar를 노래시간만큼 이동시키고 싶다

public class PlayTimeline : MonoBehaviour
{
    public GameObject fileBrowser;
    public AudioSource audio;
    public GameObject keyBar;
    RectTransform rtKeybar;
    float firstKeyBarPos;
    Vector3 saveKeyBarPos;
    float keyBarSpeed;
    bool isMove = false;
    float currentTime;
    public bool isPlay;

    public GameObject playButton;
    Image img;
    Color originColor = new Color32(255, 255, 255, 255);
    Color playColor = new Color32(255, 255, 255, 150);

    // Start is called before the first frame update
    void Start()
    {
        audio = fileBrowser.GetComponent<AudioSource>();
        saveKeyBarPos = keyBar.transform.position;
        keyBarSpeed = 30;
        rtKeybar = keyBar.GetComponent<RectTransform>();
        firstKeyBarPos = rtKeybar.anchoredPosition.x;
        isPlay = false;
        img = playButton.GetComponent<Image>();       
    }

    // Update is called once per frame
    void Update()
    {
        if(isMove == true)
        {
            // 음악이 틀어져있는 동안
            // keybar를 이동시키고 싶다
            KeyBarMove();
            //if (FileBrowserTest.instance.audioSource.clip.length < currentTime)
            //{
            //    currentTime = 0;
            //    isMove = false;              
            //}
            if(rtKeybar.anchoredPosition.x >= firstKeyBarPos + FileBrowserTest.instance.audioSource.clip.length * 30)
            {
                isMove = false;
                isPlay = false;
            }
        }

        if(isPlay == true)
        {
            img.color = playColor;
        }
        else
        {
            img.color = originColor;
        }
    }

    // 재생 버튼을 누르면 노래를 플레이하고
    // keybar를 이동시키고 싶다
    public void OnClickPlayTimeline()
    {
        if(isPlay == false)
        {
            isPlay = true;
            // keybar를 처음 위치로 이동시키고
            keyBar.transform.position = saveKeyBarPos;
            // 재생 버튼을 누르면 노래를 플레이하고
            audio.Stop();
            audio.time = 0;
            audio.Play();
            // keybar를 이동시키고 싶다
            isMove = true;
        }
        else
        {
            isPlay = false;
            audio.Stop();
            isMove = false;
        }
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
