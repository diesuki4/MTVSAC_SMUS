using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ArtistScrollScript : MonoBehaviour
{
    // 팝업창
    public RectTransform popUp;
    public RectTransform addPopUp;
    public Text showName;
    // 버튼들 들어있는 content
    public Transform parent;

    public RectTransform option;

    public GameObject optionButton;
    public GameObject closeButton;

    public Transform[] names = new Transform[2];

    // Start is called before the first frame update
    void Start()
    {
        popUp.gameObject.SetActive(false);
        option.gameObject.SetActive(false);

        names[0].gameObject.SetActive(false);
        names[1].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowThumbnail();
    }

    // 공연 썸네일 누르면 팝업이 떠야해
    public void ClickShowThumbnail()
    {
        popUp.gameObject.SetActive(true);
        popUp.DOScale(new Vector2(1, 1), 0.3f).SetEase(Ease.OutExpo);

        // 공연이름 부분에 방금 누른 버튼 이름이 들어가야해
        showName.text = EventSystem.current.currentSelectedGameObject.name;
    }
    public void ClickShowAddPopUp()
    {
        addPopUp.gameObject.SetActive(true);
    }

    void ShowThumbnail()
    {
        // 방금 누른애가 parent 자식이면 팝업 띄워
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject == null) return;
            else if (EventSystem.current.currentSelectedGameObject.name == "AddButton") return;
            if (EventSystem.current.currentSelectedGameObject.transform.parent.parent == parent)
            {
                popUp.gameObject.SetActive(true);
                popUp.DOScale(new Vector2(1, 1), 0.3f).SetEase(Ease.OutExpo);

                // 공연이름 부분에 방금 누른 버튼 이름이 들어가야해
                showName.text = EventSystem.current.currentSelectedGameObject.name;
            }
        }
    }

    // 마우스 눌렀는데 닿은 애가 parent의 자식이 아니면 팝업 꺼져야해
    public void ClosePopUp()
    {
        popUp.gameObject.SetActive(false);
    }
    
    public void CloseAddPopUp()
    {
        addPopUp.gameObject.SetActive(false);
    }

    public void ClickOptionButton()
    {
        option.gameObject.SetActive(true);
        option.DOScale(new Vector2(0.9f, 0.9f), 0.1f);
    }

    public void ClickOptionCloseButton()
    {
        option.DOScale(new Vector2(0.6f, 0.6f), 0.2f);
        option.gameObject.SetActive(false);
    }

    public void ShowYourName(int i)
    {
        names[i].gameObject.SetActive(true);
    }
    public void GetAwayName(int i)
    {
        names[i].gameObject.SetActive(false);
    }


}
