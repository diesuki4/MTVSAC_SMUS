using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelItem : MonoBehaviour
{
    enum Mode
    {
        Model       = 2 << 0,
        Thumbnail   = 2 << 1
    }

    public Canvas cnvsPalette;
    public GameObject goModel;
    public GameObject goThumbnail;
    public Transform trThumbnailArea;

    GameObject model;
    GameObject thumbnail;

    GraphicRaycaster grpRaycaster;
    EventSystem evtSystem;

    void Start()
    {
        grpRaycaster = cnvsPalette.GetComponent<GraphicRaycaster>();
        evtSystem = cnvsPalette.GetComponent<EventSystem>();
    }

    void Update() { }

    bool GraphicRaycast(Vector2 position)
    {
        PointerEventData evtData = new PointerEventData(evtSystem);
        evtData.position = position;

        List<RaycastResult> rayResults = new List<RaycastResult>();

        grpRaycaster.Raycast(evtData, rayResults);

        if (0 < rayResults.Count)
            return true;
        else
            return false;
    }

    bool ScreenPointRaycast(Vector3 screenPoint, out RaycastHit hit, int layerMask = ~0)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);

        return Physics.Raycast(ray, out hit, float.MaxValue, layerMask);
    }

    void RevalidateItem(Mode mode, Vector3 position)
    {
        switch (mode)
        {
            case Mode.Model :
                model.SetActive(true);
                model.transform.position = position;
                thumbnail.SetActive(false);
                break;
            case Mode.Thumbnail :
                model.SetActive(false);
                thumbnail.GetComponent<RectTransform>().anchoredPosition = position;
                thumbnail.SetActive(true);
                break;
        }
    }

    public void OnElementPointerDown()
    {
        if (model == null)
            model = Instantiate(goModel);

        if (thumbnail == null)
            thumbnail = Instantiate(goThumbnail, trThumbnailArea);

        RevalidateItem(Mode.Thumbnail, Input.mousePosition);
    }

    public void OnElementDrag()
    {
        RaycastHit hit;
        bool result = ScreenPointRaycast(Input.mousePosition, out hit, 1 << LayerMask.NameToLayer("Floor"));
        bool isPointerOverUI = GraphicRaycast(Input.mousePosition);

        if (result == false || isPointerOverUI)
            RevalidateItem(Mode.Thumbnail, Input.mousePosition);
        else
            RevalidateItem(Mode.Model, hit.point);
    }

    public void OnElementPointerUp()
    {
        if (model.activeSelf)
            model = null;
        else
            Destroy(model);
        
        Destroy(thumbnail);
    }
}
