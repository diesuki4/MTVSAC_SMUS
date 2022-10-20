using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove : MonoBehaviour
{
    GameObject objectHitPosition;
    Transform parent;
    RaycastHit hitLayerMask, hitRay;
    Vector3 distance;

    BlockMove blockMove;

    public int gridSize;

    // 마우스 떼면
    private void OnMouseUp()
    {
        // 부모 다시 옮겨주고
        this.transform.parent = parent;
        // 잠깐 썼던 부모 삭제
        Destroy(objectHitPosition);
    }

    // 마우스 누르면
    private void OnMouseDown()
    {
        // 레이 만들어서 쏘고
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitRay))
        {
            // 새 부모 만들어서
            objectHitPosition = new GameObject("HitPosition");
            // 레이 맞은 위치에 두고
            objectHitPosition.transform.position = hitRay.point;
            // 큐브를 얘 자식으로 줘
            this.transform.SetParent(objectHitPosition.transform);
            this.transform.position = new Vector3(0, 0, 0);
        }
    }

    // 드래그 하면
    private void OnMouseDrag()
    {
        // 레이 만들어서 쏘고
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        int layerMask = 1 << LayerMask.NameToLayer("Stage");
        if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
        {
            // 움직여
            float H = Camera.main.transform.position.y;
            float h = objectHitPosition.transform.position.y;

            Vector3 newPos = (hitLayerMask.point * (H - h) + Camera.main.transform.position * h) / H;

            float x = (int)Mathf.FloorToInt(newPos.x);
            float y = (int)Mathf.FloorToInt(newPos.y);
            float z = (int)Mathf.FloorToInt(newPos.z);

            objectHitPosition.transform.position = newPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 지금 부모 저장해두고
        parent = transform.parent.transform;

        blockMove = transform.GetComponent<BlockMove>();
        distance = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
