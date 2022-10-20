using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectBlock : MonoBehaviour
{
    RaycastHit hit;
    Transform selectedTarget;

    Material outline;
    Renderer renderers;
    List<Material> materialList = new List<Material>();

    static SelectBlock instance = null;
    public static SelectBlock Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<SelectBlock>();
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // outline shader
        outline = new Material(Shader.Find("Draw/OutlineShader"));
    }

    // 아웃라인 그리기
    void AddOutline(Transform obj)
    {
        if (obj == null) return;

        renderers = obj.GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outline);

        renderers.materials = materialList.ToArray();
    }

    // 아웃라인 지우기
    void RemoveOutline(Renderer renderer)
    {
        if (renderer != null)
        {
            materialList.Clear();
            materialList.AddRange(renderer.sharedMaterials);
            materialList.Remove(outline);

            renderer.materials = materialList.ToArray();
        }
    }

    // 타겟이 없어 = 너 방금 오브젝트 안 찍었어
    void ClearTarget()
    {
        if (selectedTarget == null) return;

        BlockMove blockMove = selectedTarget.transform.GetComponent<BlockMove>();
        blockMove.selected = false;
        selectedTarget = null;
        RemoveOutline(renderers);
    }

    // 너 방금 타겟 골랐어
    void SelectTarget(Transform obj)
    {
        if (obj == null) return;

        if (obj == selectedTarget)
        {
            ClearTarget();
            return;
        }
        BlockMove blockMove = obj.transform.GetComponent<BlockMove>();
        blockMove.selected = !blockMove.selected;

        ClearTarget();
        selectedTarget = obj;
        AddOutline(obj);
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 누르면
        if (Input.GetMouseButtonDown(0))
        {
            // 레이 만들어서
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
            int layer = 1 << LayerMask.NameToLayer("Object");

            // 레이 쏘고
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                // 맞은 애 SelectTarget 해주깅
                Transform obj = hit.transform;
                SelectTarget(obj);

                // selected == true면 false로 false면 true로
                // 아까 배운 거 걍 쓰믄 되나
                //BlockMove blockMove = obj.transform.GetComponent<BlockMove>();
                //blockMove.selected = !blockMove.selected;
            }
            // 닿은 게 Ui면
            else if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            else // Object 선택 안 했으면
            {
                ClearTarget();
            }
        }
    }
}
