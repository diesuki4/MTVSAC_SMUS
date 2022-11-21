using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 생성했을 때 배경화면을 선택하고
// 선택하면 quad가 그 이미지로 바뀌게 하고 싶다

public class InputBG : MonoBehaviour
{
    public GameObject fileBrowser;
    FileBrowserTest fbt;

    // Start is called before the first frame update
    void Start()
    {
        fbt = fileBrowser.GetComponent<FileBrowserTest>();
        //fbt.ShowFileBrowserInputImage();
        fbt.ShowFileBrowserInputVideo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
