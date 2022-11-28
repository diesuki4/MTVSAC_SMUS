using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DottweenUI : MonoBehaviour
{
    public GameObject saveNameUi;
    public GameObject confirmUi;
    SaveTimeline st;
    public GameObject inputConcertName;
    InputField concertNameInputField;

    // Start is called before the first frame update
    void Start()
    {
        st = this.GetComponent<SaveTimeline>();
        concertNameInputField = inputConcertName.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSaveNameUiOn()
    {
        confirmUi.SetActive(false);
        StartCoroutine("UiAnimationOn", saveNameUi);
    }

    public void OnClickSaveNameUiOff()
    {
        StartCoroutine("UiAnimationOff", saveNameUi);
    }

    public void OnClickSaveNameSaveButton()
    {
        st.OnClickSaveTimeline();
        saveNameUi.SetActive(false);
        StartCoroutine("UiAnimationOn", confirmUi);
    }

    public void OnClickConfirmUiOff()
    {
        StartCoroutine("UiAnimationOff", confirmUi);
    }

    IEnumerator UiAnimationOn(GameObject go)
    {
        go.SetActive(true);
        go.transform.localScale = Vector3.zero;
        go.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(0.25f);
    }

    IEnumerator UiAnimationOff(GameObject go)
    {
        go.transform.DOScale(0f, 0.5f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(0.4f);
        go.SetActive(false);
    }
}
