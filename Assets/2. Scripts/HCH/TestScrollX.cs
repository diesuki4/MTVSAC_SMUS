using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// TimelineTimerBase의 content x축이동과 TimeArea, MusicWaveArea의 content x축이동을 동기화 하고 싶다
public class TestScrollX : MonoBehaviour
{
    public static TestScrollX instance;

    public GameObject timerBaseContent;
    public GameObject objectBaseContent;
    public GameObject timeAreaContent;
    public GameObject musicWaveAreaContent;

    public RectTransform objectHeight;
    public RectTransform timerHeight;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        objectHeight = objectBaseContent.GetComponent<RectTransform>();
        timerHeight = timerBaseContent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        ContentMoveX();
        ContentMoveY();
        ContentHeightSync();
    }

    // TimelineTimerBase의 content x축 이동과 TimeArea, MusicWaveArea의 content x축 이동을 동기화 하고 싶다
    public void ContentMoveX()
    {
        float timerBaseContentPosX = timerBaseContent.transform.position.x;
        float timerAreaContentPosX = timeAreaContent.transform.position.x;
        float musicWaveAreaContentPosX = musicWaveAreaContent.transform.position.x;

        timerAreaContentPosX = timerBaseContentPosX;
        musicWaveAreaContentPosX = timerBaseContentPosX;

        timeAreaContent.transform.position = new Vector2(timerAreaContentPosX, timeAreaContent.transform.position.y);
        musicWaveAreaContent.transform.position = new Vector2(musicWaveAreaContentPosX, musicWaveAreaContent.transform.position.y);
    }

    // TimelineTimerBase의 content y축 이동과 TimelineObjectBase의 content y축 이동을 동기화 하고 싶다
    public void ContentMoveY()
    {
        float timerBaseContentPosY = timerBaseContent.transform.position.y;
        float objectBaseContentPosY = objectBaseContent.transform.position.y;

        objectBaseContentPosY = timerBaseContentPosY;

        objectBaseContent.transform.position = new Vector2(objectBaseContent.transform.position.x, objectBaseContentPosY);
    }

    // TimelineTimerBase의 content길이를 TimelineObjectBase의 content 길이에 맞추고 싶다
    public void ContentHeightSync()
    {
        Rect oHeight = objectHeight.rect;
        Rect tHeight = timerHeight.rect;
  
        tHeight.height = oHeight.height;
    }
}
