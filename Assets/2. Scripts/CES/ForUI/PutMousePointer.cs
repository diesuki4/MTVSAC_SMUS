using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutMousePointer : MonoBehaviour
{
    public static PutMousePointer instance;

    public Button weightlessness;
    public Transform weightlessnessImage;

    public bool isWeightlessness = false;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        weightlessnessImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWeightlessness == true)
        {
            weightlessness.GetComponent<Image>().color = new Color(102f / 255f, 102f / 255f, 255f / 255f);
        }
        else
        {
            weightlessness.GetComponent<Image>().color = Color.white;
        }
    }

    public void OnMouseEnter()
    {
        weightlessnessImage.gameObject.SetActive(true);
    }
    public  void OnMouseExit()
    {
        weightlessnessImage.gameObject.SetActive(false);
    }

    public void ChangeGravity()
    {
        isWeightlessness = !isWeightlessness;
    }
}
