using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Utility;
using System.IO;
using UnityEngine.SceneManagement;
// 타임라인 진행상황을 로컬에 저장하고 싶다

public class SaveTimeline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSaveTimeline()
    {
        File.WriteAllText(Application.dataPath + "/1.cdata", TL_Utility.ToCDATA(TimelineManager.Instance.GetTimelines()));
    }

    public void OnClickLoadTimeline()
    {
        
    }

    public void OnClickExitButton(string sceneName)
    {
        PlayerPrefs.SetInt("Created", 1);
        SceneManager.LoadScene(sceneName);
    }
}
