using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagButton : MonoBehaviour
{
    public Transform[] listParent = new Transform[5];

    RectTransform ver1Content;

    // Start is called before the first frame update
    void Start()
    {
        ver1Content = gameObject.GetComponent<AddRectLength>().ver1Content;

        listParent[0].gameObject.SetActive(true);
        listParent[1].gameObject.SetActive(false);
        listParent[2].gameObject.SetActive(false);
        listParent[3].gameObject.SetActive(false);
        listParent[4].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 나는야 노가다의 신

    public void TagOneClick()
    {
        for (int i = 0; i < listParent.Length; i++)
        {
            listParent[i].gameObject.SetActive(false);
        }
        listParent[0].gameObject.SetActive(true);

        RectTransform findParent = (RectTransform)listParent[0];
        RectTransform contentOfParent = (RectTransform)listParent[0].GetChild(0).transform.GetChild(0);
        int childCount = contentOfParent.transform.childCount;
        int row = childCount / 4;

        ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, 1265.583f + (row * 450)/*ver1Content.sizeDelta.y + 450*/);
        findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
    }

    public void TagTwoClick()
    {
        for (int i = 0; i < listParent.Length; i++)
        {
            listParent[i].gameObject.SetActive(false);
        }
        listParent[1].gameObject.SetActive(true);

        RectTransform findParent = (RectTransform)listParent[1];
        RectTransform contentOfParent = (RectTransform)listParent[1].GetChild(0).transform.GetChild(0);
        int childCount = contentOfParent.transform.childCount;
        int row = childCount / 4;

        ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, 1265.583f + (row * 450)/*ver1Content.sizeDelta.y + 450*/);
        findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
    }

    public void TagThreeClick()
    {
        for (int i = 0; i < listParent.Length; i++)
        {
            listParent[i].gameObject.SetActive(false);
        }
        listParent[2].gameObject.SetActive(true);

        RectTransform findParent = (RectTransform)listParent[2];
        RectTransform contentOfParent = (RectTransform)listParent[2].GetChild(0).transform.GetChild(0);
        int childCount = contentOfParent.transform.childCount;
        int row = childCount / 4;

        ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, 1265.583f + (row * 450)/*ver1Content.sizeDelta.y + 450*/);
        findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
    }

    public void TagFourClick()
    {
        for (int i = 0; i < listParent.Length; i++)
        {
            listParent[i].gameObject.SetActive(false);
        }
        listParent[3].gameObject.SetActive(true);

        RectTransform findParent = (RectTransform)listParent[3];
        RectTransform contentOfParent = (RectTransform)listParent[3].GetChild(0).transform.GetChild(0);
        int childCount = contentOfParent.transform.childCount;
        int row = childCount / 4;

        ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, 1265.583f + (row * 450)/*ver1Content.sizeDelta.y + 450*/);
        findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
    }

    public void TagFiveClick()
    {
        for (int i = 0; i < listParent.Length; i++)
        {
            listParent[i].gameObject.SetActive(false);
        }
        listParent[4].gameObject.SetActive(true);

        RectTransform findParent = (RectTransform)listParent[4];
        RectTransform contentOfParent = (RectTransform)listParent[4].GetChild(0).transform.GetChild(0);
        int childCount = contentOfParent.transform.childCount;
        int row = childCount / 4;

        ver1Content.sizeDelta = new Vector2(ver1Content.sizeDelta.x, 1265.583f + (row * 450)/*ver1Content.sizeDelta.y + 450*/);
        findParent.sizeDelta = new Vector2(findParent.sizeDelta.x, contentOfParent.sizeDelta.y);
    }
}
