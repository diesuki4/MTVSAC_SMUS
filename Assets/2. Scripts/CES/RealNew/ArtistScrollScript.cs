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
    public Text showName;
    // 버튼들 들어있는 content
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        popUp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ClosePopUp();
    }

    // 공연 썸네일 누르면 팝업이 떠야해
    public void ClickShowThumbnail()
    {
        popUp.gameObject.SetActive(true);
        popUp.DOScale(new Vector2(1, 1), 0.3f).SetEase(Ease.OutExpo);

        // 공연이름 부분에 방금 누른 버튼 이름이 들어가야해
        showName.text = EventSystem.current.currentSelectedGameObject.name;
    }

    // 마우스 눌렀는데 닿은 애가 parent의 자식이 아니면 팝업 꺼져야해
    void ClosePopUp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(EventSystem.current.currentSelectedGameObject);
            // 눌린 게 없거나
            if (EventSystem.current.currentSelectedGameObject == null) popUp.gameObject.SetActive(false);
            // 부모개체가 없거나
            else if (EventSystem.current.currentSelectedGameObject.transform.parent == null) popUp.gameObject.SetActive(false);
            // 부모가 parent가 아니면
            else if (EventSystem.current.currentSelectedGameObject.transform.parent.parent != parent) popUp.gameObject.SetActive(false);
        }
    }
}
