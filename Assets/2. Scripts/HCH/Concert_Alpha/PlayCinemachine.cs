using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
// P버튼을 누르면 시네머신을 시작하고
// 캐릭터들의 애니메이션을 실행하고 싶다

public class PlayCinemachine : MonoBehaviour
{
    public static PlayCinemachine instance;

    PlayableDirector pd;
    public GameObject character_Small; 
    public GameObject character_Big;
    Animator smallAnim;
    Animator bigAnim;
    SkinnedMeshRenderer smr;
    public bool startCameraMove;

    public Camera firstCam;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        smallAnim = character_Small.GetComponent<Animator>();
        bigAnim = character_Big.GetComponent<Animator>();
        smr = character_Big.GetComponentInChildren<SkinnedMeshRenderer>();
        startCameraMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayCin();
        ReloadCin();
        BackScene();
    }

    public void PlayCin()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            firstCam.enabled = false;
            // 시네머신을 실행하고
            pd.Play();
            // 작은 캐릭터 애니메이션을 실행하고
            smallAnim.SetTrigger("RealPlay");
            // 큰 캐릭터 애니메이션을 실행하고
            bigAnim.SetTrigger("RealPlay");
            // 큰 캐릭터 meshrenderer를 켜고 싶다 
            smr.enabled = true;
            startCameraMove = true;
        }
    }

    public void ReloadCin()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 씬을 다시 로드하고 싶다
            SceneManager.LoadScene("Concert_Alpha_HCH");
        }
    }

    public void BackScene()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 내 공연 씬으로 돌아가고 싶다
            SceneManager.LoadScene("ArtistConcertListScene_C");
        }
    }
}
