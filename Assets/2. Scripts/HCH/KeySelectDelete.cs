using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// key를 선택하면 색깔로 구분할 수 있게 하고
// 선택한 상태에서 delete키를 누르면 destroy하고 싶다

public class KeySelectDelete : MonoBehaviour
{
    public bool isSelected;
    public bool isActived;
    Image img;
    Color focusColor = new Color32(168, 255, 255, 255);
    Color deActivationColor = new Color32(255, 0, 0, 255);
    Color originColor;

    TimelineKey tk;
    string guid;
    int saveFrame;

    // Start is called before the first frame update
    void Start()
    {
        tk = this.GetComponent<TimelineKey>();
        img = GetComponent<Image>();

        isSelected = false;
        isActived = tk.active;
        originColor = img.color;

        img.color = (isActived) ? originColor : deActivationColor;

        guid = tk.guid;
    }

    // Update is called once per frame
    void Update()
    {
        KeyManagement();
        DeleteKey();
        KeyActiveManagement();
    }

    // Key를 선택상태로 만들고 싶다
    // key를 선택하면 색깔로 구분할 수 있게 하고 싶다
    public void KeySelect()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isSelected = true;
            img.color = focusColor;
        }
    }

    // 선택상태에서 좌클릭시 선택 상태를 해제하고 싶다
    // 선택 상태 해제 시 색깔을 원래대로 하고 싶다
    public void KeyDeselect()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isSelected = false;
            if(isActived == true)
            {
                img.color = originColor;
            }
            else
            {
                img.color = deActivationColor;
            }
        }
    }

    // 선택한 상태에서 delete키를 누르면 destroy하고 싶다
    public void DeleteKey()
    {
        // 선택 상태일 때 delete를 누르면 destroy하고 싶다
        if (isSelected == true)
        {
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                Destroy(gameObject);
                TimelineManager.Instance.DeleteKey(guid, tk.frame);
            }
        }
    }

    // ObjectKey 선택, 삭제
    public void KeyManagement()
    {
        if(SubLineManager.instance.results.Count > 0)
        {
            // graphic raycaster에 이 오브젝트가 닿고
            if (0 < KeyManager.instance.objectKeyList.Count && SubLineManager.instance.results[0].gameObject == this.gameObject)
            {
                // isSelected가 false라면 선택 상태로 하고 
                if (isSelected == false)
                {
                    KeySelect();
                }
                // isSelected가 true라면 선택 상태를 해제한다
                else
                {
                    KeyDeselect();
                }
                // 다른 곳을 클릭해도 선택 상태를 해제한다    
            }
            else
            {
                KeyDeselect();
            }
        }      
    }

    // 키 SetActive true
    public void KeySetActiveTrue()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            tk.active = isActived = true;
            img.color = originColor;
            TimelineObject tl_object = BuildingSystem.Instance.getTimelineObject(guid);
            tl_object.isActive = true;
            TimelineManager.Instance.UpdateKey(tk);
        }
    }

    // 키 SetActive false
    public void KeySetActiveFalse()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            tk.active = isActived = false;
            img.color = deActivationColor;
            TimelineObject tl_object = BuildingSystem.Instance.getTimelineObject(guid);
            tl_object.isActive = false;
            TimelineManager.Instance.UpdateKey(tk);
        }
    }

    // 키 SetActive관리
    public void KeyActiveManagement()
    {
        if (SubLineManager.instance.results.Count > 0)
        {
            // graphic raycaster에 이 오브젝트가 닿고
            if (0 < KeyManager.instance.objectKeyList.Count && SubLineManager.instance.results[0].gameObject == this.gameObject)
            {
                // isActived가 true라면 우클릭 했을 때 false로
                if (isActived == true)
                {
                    KeySetActiveFalse();
                }
                // isActived가 false라면 우클릭 했을 때 true로
                else
                {
                    KeySetActiveTrue();
                }
            }
        }
    }
}
