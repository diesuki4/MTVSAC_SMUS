using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// 공연 버튼을 누르면 concertId를 저장하고 싶다

public class ConcertDataManager : MonoBehaviour
{
    public static ConcertDataManager instance;

    public ConcertInfo concertInfo;
    public int concert_Id;

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
        PlayerPrefs.SetInt("concert_id", concert_Id);
        SceneManager.LoadScene("Concert_Beta_HCH");
        print(concert_Id);
    }

    public void OnClickModify()
    {
        PlayerPrefs.SetInt("concert_id", concert_Id);
        SceneManager.LoadScene("Studio_Alpha_HCH");
        print(concert_Id);
    }
}
