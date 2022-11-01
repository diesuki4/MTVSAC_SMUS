using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UI.Utility;

public class PanelItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    // 아이템 드래그 시 모드
    enum Mode
    {
        Model       = 1 << 0,   // 바닥에 모델이 표시되는 모드
        Thumbnail   = 1 << 1    // 썸네일이 표시되는 모드
    }

    [Header("팔레트")]
    public Canvas cnvsPalette;
    [Header("모델")]
    public GameObject goModel;
    [Header("썸네일")]
    public GameObject goThumbnail;
    [Header("썸네일 표시를 위한 영역")]
    public RectTransform rctThumbnailArea;

    GameObject model;       // 선택된 모델
    GameObject thumbnail;   // 선택된 썸네일

    void Start() { }

    void Update() { }

    // 모델 혹은 썸네일을 position 위치에 표시
    void RevalidateItem(Mode mode, Vector3 position)
    {
        switch (mode)
        {
            // Model 모드이면
            case Mode.Model :
                // 모델을 보이게 하고
                model.SetActive(true);
                // 위치를 이동시키고
                model.GetComponent<ObjectDrag>().MouseDrag();
                // 썸네일을 끈다.
                thumbnail.SetActive(false);
                break;
            // Thumbnail 모드이면
            case Mode.Thumbnail :
                // 모델을 안 보이게 하고
                model.SetActive(false);
                // 그리드를 다시 그리고
                BuildingSystem.Instance.ClearGrid(model.GetComponent<PlaceableObject>());
                // 썸네일을 이동시키고
                thumbnail.GetComponent<RectTransform>().anchoredPosition = position;
                // 썸네일을 보이게 한다.
                thumbnail.SetActive(true);
                break;
        }
    }

    // IPointerDownHandler
    // 마우스 버튼을 눌렀을 때
    public void OnPointerDown(PointerEventData data)
    {
        // 해당 모델을 생성
        if (model == null)
            model = BuildingSystem.Instance.Instantiate(goModel);

        // 해당 썸네일을 생성
        if (thumbnail == null)
            thumbnail = Instantiate(goThumbnail, rctThumbnailArea);
            
        // 썸네일을 포인터 위치에 표시
        RevalidateItem(Mode.Thumbnail, Input.mousePosition);
    }

    // IDragHandler
    // 마우스 버튼을 누르고 드래그 중일 때
    public void OnDrag(PointerEventData data)
    {
        RaycastHit hit;
        // 포인터 위치에서 바닥에 Ray 를 쏜다.
        bool result = UI_Utility.ScreenPointRaycast(Camera.main, Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor"));
        // UI 위에 포인터가 있는지 확인
        bool isPointerOverUI = UI_Utility.GraphicRaycast(cnvsPalette, Input.mousePosition);

        // 포인터가 바닥에 있지 않거나
        // UI 위에 포인터가 있으면
        if (result == false || isPointerOverUI)
            // 썸네일을 포인터 위치에 표시
            RevalidateItem(Mode.Thumbnail, Input.mousePosition);
        // 이외에는
        else
            // 바닥에 Ray 가 맞은 위치에 모델을 표시
            RevalidateItem(Mode.Model, hit.point);
    }

    // IPointerUpHandler
    // 마우스 버튼을 뗐을 때
    public void OnPointerUp(PointerEventData data)
    {
        model.GetComponent<ObjectDrag>().MouseUp();

        if (model.GetComponent<PlaceableObject>().isPlaced == false)
            Destroy(model);

        model = null;

        // 썸네일은 무조건 제거
        Destroy(thumbnail);
    }
}
