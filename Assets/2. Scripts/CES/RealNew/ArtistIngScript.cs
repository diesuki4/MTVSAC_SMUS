using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ArtistIngScript : MonoBehaviour
{
    bool uiSetActive = true;
    public Transform uis;
    public RectTransform skillSetImage;
    bool iCanSeeShowInfo = false;
    public RectTransform warningImage;
    Transform namee;
    public Text push;
    public Sprite[] dropdownImages = new Sprite[2];

    // Start is called before the first frame update
    void Start()
    {
        warningImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyBlocker();
        SuperviseUI();
        GoBackShowInfoImage();
        StartTheShow();
        InsertImage();
    }

    // 드롭다운 내려왔을 때 다른 곳 누르면 무조건 드롭다운 들어가게 하는 애 없애기
    void DestroyBlocker()
    {
        if (GameObject.Find("Blocker") == null) return;
        Destroy(GameObject.Find("Blocker"));
    }

    // UI 끄는 버튼 누르면 UIs가 셋액티브 false되고 버튼은 반투명해짐
    public void ClickSuperviseButton()
    {
        uiSetActive = !uiSetActive;
    }
    void SuperviseUI()
    {
        if (uiSetActive)
        {
            uis.gameObject.SetActive(true);
            GameObject.Find("UISetActiveButton").GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            uis.gameObject.SetActive(false);
            GameObject.Find("UISetActiveButton").GetComponent<Image>().color = new Color(1, 1, 1, 30 / 255f);
        }
    }

    // 드롭다운 메뉴들
    public void ClickDd()
    {
        // Item 0: Option A
        if (EventSystem.current.currentSelectedGameObject.transform.parent.name.Substring(5, 1) == "0") DdSkillSet();
        else if (EventSystem.current.currentSelectedGameObject.transform.parent.name.Substring(5, 1) == "1") DdExitShow();
    }
    void DdSkillSet() // 0
    {
        skillSetImage.DOAnchorPosX(-710, 0.2f).SetEase(Ease.OutExpo);
        iCanSeeShowInfo = true;
    }
    void DdExitShow() // 1
    {
        warningImage.gameObject.SetActive(true);
        warningImage.DOScale(new Vector2(1, 1), 0.1f).SetEase(Ease.Linear);
    }

    // 쇼인포이미지 돌려보내기
    void GoBackShowInfoImage()
    {
        if (iCanSeeShowInfo && Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != skillSetImage) skillSetImage.DOAnchorPosX(-1400, 0.2f).SetEase(Ease.InExpo);
        }
    }
    // 경고이미지 없애기
    public void ClickNoExit()
    {
        warningImage.DOScale(new Vector2(0.4f, 0.4f), 0.1f);
        //warningImage.gameObject.SetActive(false);
        namee = warningImage.transform;
        Invoke("SetActiveFalseDelay", 0.12f);
    }

    void SetActiveFalseDelay()
    {
        namee.gameObject.SetActive(false);
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

    void InsertImage()
    {
        if (GameObject.Find("Item 0: SkillSet") != null)
        {
            GameObject.Find("Item 0: SkillSet").GetComponentInChildren<Image>().sprite = dropdownImages[0];
            GameObject.Find("Item 1: Exit").GetComponentInChildren<Image>().sprite = dropdownImages[1];
        }
    }
}
