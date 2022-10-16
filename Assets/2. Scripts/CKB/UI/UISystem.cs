using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public static UISystem Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public enum Tab
    {
        Object  = 2 << 0,
        Effect  = 2 << 1,
        Light   = 2 << 2,
        Avatar  = 2 << 3,
        ETC1    = 2 << 4,
        ETC2    = 2 << 5,
        ETC3    = 2 << 6,
    }
    public Tab selectedTab;

    public RectTransform rctTabs;
    public Color clrEmphasizedTab;
    public Color clrUnemphasizedTab;
    public RectTransform rctPanels;

    void Start()
    {
        selectedTab = IndexToTab(0);

        FocusTab(rctTabs.GetChild(0).gameObject);
        FocusPanel(rctPanels.GetChild(0).gameObject);
    }

    void Update() { }

    Tab IndexToTab(int index)
    {
        return (Tab)(2 << index);
    }

    void EmphasizeTab(GameObject tab, bool emphasize)
    {
        Image image = tab.GetComponent<Image>();

        if (image)
            image.color = (emphasize) ? clrEmphasizedTab : clrUnemphasizedTab;
    }

    void EmphasizeTabs(bool emphasize)
    {
        foreach (Transform tab in rctTabs)
            EmphasizeTab(tab.gameObject, emphasize);
    }

    void FocusTab(GameObject tab)
    {
        EmphasizeTabs(false);
        EmphasizeTab(tab, true);
    }

    void ShowPanel(GameObject panel, bool show)
    {
        panel.SetActive(show);
    }

    void ShowPanels(bool show)
    {
        foreach (Transform panel in rctPanels)
            ShowPanel(panel.gameObject, show);
    }

    void FocusPanel(GameObject panel)
    {
        ShowPanels(false);
        ShowPanel(panel, true);
    }

    public void OnClickTabButton(int index)
    {
        GameObject tab = rctTabs.GetChild(index).gameObject;
        GameObject panel = rctPanels.GetChild(index).gameObject;

        FocusTab(tab);
        FocusPanel(panel);
    }

    public void OnElementPointerDown()
    {
        print(MethodBase.GetCurrentMethod().Name);
    }

    public void OnElementDrag()
    {
        print(MethodBase.GetCurrentMethod().Name);
    }

    public void OnElementPointerUp()
    {
        print(MethodBase.GetCurrentMethod().Name);
    }
}
