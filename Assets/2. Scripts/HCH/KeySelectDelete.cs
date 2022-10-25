using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// key를 선택하면 색깔로 구분할 수 있게 하고
// 선택한 상태에서 delete키를 누르면 destroy하고 싶다

public class KeySelectDelete : MonoBehaviour
{
    public bool isSelected;
    Image img;
    Color focusColor = new Color32(168, 255, 255, 255);
    Color originColor;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        img = GetComponent<Image>();
        originColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        KeyManagement();
        DeleteKey();
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
            img.color = originColor;
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
}
