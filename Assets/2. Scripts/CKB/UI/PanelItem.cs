using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelItem : MonoBehaviour
{
    enum Mode
    {
        Model       = 2 << 0,
        Thumbnail   = 2 << 1
    }

    public GameObject goModel;
    public GameObject goThumbnail;
    public Transform trThumbnailArea;

    GameObject model;
    GameObject thumbnail;

    void Start() { }

    void Update() { }

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
        bool result = ScreenPointRaycast(Input.mousePosition, out hit);

        if (result && model != hit.transform.gameObject && EventSystem.current.IsPointerOverGameObject())
            RevalidateItem(Mode.Model, hit.point);
        else
            RevalidateItem(Mode.Thumbnail, Input.mousePosition);
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
