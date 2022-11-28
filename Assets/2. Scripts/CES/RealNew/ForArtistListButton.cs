//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using DG.Tweening;
//using UnityEngine.EventSystems;

//public class ForArtistListButton : MonoBehaviour
//{
//    Transform popUp;
//    Text showName;

//    // Start is called before the first frame update
//    void Start()
//    {
//        popUp = GameObject.Find("Popup_ArtistScroll").transform;
//        showName = GameObject.Find("ShowName").GetComponent<Text>();

//        transform.GetComponent<Button>().onClick.AddListener(ClickShowThumbnail);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    void ClickShowThumbnail()
//    {
//        popUp.gameObject.SetActive(true);
//        popUp.DOScale(new Vector2(1, 1), 0.3f).SetEase(Ease.OutExpo);

//        // 공연이름 부분에 방금 누른 버튼 이름이 들어가야해
//        //showName.text = EventSystem.current.currentSelectedGameObject.name;
//    }
//}
