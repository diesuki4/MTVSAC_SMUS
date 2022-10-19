using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    // 팔레트에 있는 탭의 종류
    public enum Type
    {
        Object  = 1 << 0,
        Effect  = 1 << 1,
        Light   = 1 << 2,
        Avatar  = 1 << 3,
        ETC1    = 1 << 4,
        ETC2    = 1 << 5,
        ETC3    = 1 << 6
    }
    [HideInInspector]
    public Type selectedTab;    // 현재 선택된 탭

    [Header("탭들의 부모 트랜스폼")]
    public RectTransform rctTabs;
    [Header("선택된 탭의 색상")]
    public Color clrSelectedTab;
    [Header("선택되지 않은 탭의 색상")]
    public Color clrUnselectedTab;
    [Header("패널들의 부모 트랜스폼")]
    public RectTransform rctPanels;

    void Start()
    {
        // 기본으로 0번째 탭을 선택
        selectedTab = IndexToTab(0);

        FocusTab(rctTabs.GetChild(0).gameObject);
        FocusPanel(rctPanels.GetChild(0).gameObject);
    }

    void Update() { }

    // 인덱스를 Type 으로 변환
    Type IndexToTab(int index)
    {
        return (Type)(1 << index);
    }

    // emphasize 에 따라 탭의 색상을 변경
    void EmphasizeTab(GameObject tab, bool emphasize)
    {
        Image image = tab.GetComponent<Image>();

        if (image)
            image.color = (emphasize) ? clrSelectedTab : clrUnselectedTab;
    }

    // 해당 탭만을 강조
    void FocusTab(GameObject tab)
    {
        foreach (Transform childTab in rctTabs)
            EmphasizeTab(childTab.gameObject, false);

        EmphasizeTab(tab, true);
    }

    // show 에 따라 패널을 켜고 끈다
    void ShowPanel(GameObject panel, bool show)
    {
        panel.SetActive(show);
    }

    // 해당 패널만을 보여준다
    void FocusPanel(GameObject panel)
    {
        foreach (Transform childPanel in rctPanels)
            ShowPanel(childPanel.gameObject, false);

        ShowPanel(panel, true);
    }

    // 
    public void OnClickTabButton()
    {
        // index 번째 탭
        int index = transform.GetSiblingIndex();

        GameObject tab = rctTabs.GetChild(index).gameObject;
        GameObject panel = rctPanels.GetChild(index).gameObject;

        // index 에 해당하는 탭을 선택하고 패널을 보여줌
        FocusTab(tab);
        FocusPanel(panel);
    }
}
