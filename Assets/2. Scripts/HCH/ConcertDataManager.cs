using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// 공연 버튼을 누르면 concertId를 저장하고 싶다

public class ConcertDataManager : MonoBehaviour
{
    public static ConcertDataManager instance;

    public ConcertInfo concertInfo;
    public int concertId;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickShow()
    {
        PlayerPrefs.SetInt("concert_id", concertId);
        SceneManager.LoadScene("Concert_Beta_HCH");
        print(concertId);
    }

    public void OnClickModify()
    {
        PlayerPrefs.SetInt("concert_id", concertId);
        SceneManager.LoadScene("Studio_Alpha_HCH");
        print(concertId);
    }
}
