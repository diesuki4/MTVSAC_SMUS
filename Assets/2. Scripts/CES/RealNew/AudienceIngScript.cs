using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class AudienceIngScript : MonoBehaviour
{
    bool uiSetActive = true;
    public Transform uis;
    public RectTransform showInfoImage;
    bool iCanSeeShowInfo = false;
    public RectTransform warningImage;
    Transform namee;
    public Sprite[] dropdownImages = new Sprite[3];

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
            GameObject.Find("UISetActiveButton").GetComponent<Image>().color = new Color(1, 1, 1, 30/255f);
        }
    }

    // 드롭다운 메뉴들
    public void ClickDd()
    {
        // Item 0: Option A
        if (EventSystem.current.currentSelectedGameObject.transform.parent.name.Substring(5, 1) == "0") DdKeyManual();
        else if (EventSystem.current.currentSelectedGameObject.transform.parent.name.Substring(5, 1) == "1") DdShowInfo();
        else if (EventSystem.current.currentSelectedGameObject.transform.parent.name.Substring(5, 1) == "2") DdExitShow();
    }
    void DdKeyManual() // 0
    {
        showInfoImage.DOAnchorPosX(-710, 0.2f).SetEase(Ease.OutExpo);
        iCanSeeShowInfo = true;
    }
    void DdShowInfo() // 1
    {
        showInfoImage.DOAnchorPosX(-710, 0.2f).SetEase(Ease.OutExpo);
        iCanSeeShowInfo = true;
    }
    void DdExitShow() // 2
    {
        warningImage.gameObject.SetActive(true);
        warningImage.DOScale(new Vector2(1, 1), 0.1f).SetEase(Ease.Linear);
    }

    // 쇼인포이미지 돌려보내기
    void GoBackShowInfoImage()
    {
        if (iCanSeeShowInfo && Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != showInfoImage) showInfoImage.DOAnchorPosX(-1400, 0.2f).SetEase(Ease.InExpo);
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

    // 드롭다운 이미지들 넣기
    void InsertImage()
    {
        if (GameObject.Find("Item 0: KeyManual") != null)
        {
            GameObject.Find("Item 0: KeyManual").GetComponentInChildren<Image>().sprite = dropdownImages[0];
            GameObject.Find("Item 1: ShowInfo").GetComponentInChildren<Image>().sprite = dropdownImages[1];
            GameObject.Find("Item 2: Exit").GetComponentInChildren<Image>().sprite = dropdownImages[2];
        }
    }

    // 드롭다운 클릭하면 없어지게
    public void DestroyDropdownList()
    {
        if (GameObject.Find("Dropdown List") != null)// && Input.GetMouseButtonUp(0))
        {
            Destroy(GameObject.Find("Dropdown List"));
        }
    }
}
