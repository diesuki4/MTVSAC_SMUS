using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ShowManager : MonoBehaviour
{
    public Text push;
    public RectTransform warningImage;
    public GameObject warning;
    Transform namee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartTheShow();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickWarn();
        }
    }

    // 공연자 독촉하기
    void StartTheShow()
    {
        if (Input.GetKeyDown(KeyCode.P)) push.gameObject.SetActive(false);

        if (push.gameObject.activeSelf)
        {
            if (push.color.a == 1) push.DOFade(0.1f, 1f);
            else if (push.color.a < 0.11) push.DOFade(1, 1f);
        }
    }

    // 경고이미지 띄우기
    public void OnClickWarn()
    {
        warning.SetActive(true);
    }

    // 경고이미지 없애기
    public void ClickNoExit()
    {
        warning.SetActive(false);
    }

    public void OnClickBackToMyConcert()
    {
        SceneManager.LoadScene("ArtistConcertListScene_C");
    }
}
