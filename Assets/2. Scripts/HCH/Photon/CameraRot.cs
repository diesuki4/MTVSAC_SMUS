using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraRot : MonoBehaviourPun
{
    // 회전 속력 
    public float rotSpeed = 200;

    //CamPos의 Transform
    public Transform camPos;

    // 마우스 움직임 변수
    float mx;
    float my;

    //회전값 누적 변수
    float rotX;
    float rotY;

    // 카메라 배열
    GameObject[] cameras = new GameObject[11];

    // 선택할 카메라
    Transform camParent;
    public GameObject cam_Main;
    GameObject cam_CloseUp_ArtistRight;
    GameObject cam_CloseUp_ArtistLeft;
    GameObject cam_CloseUp_FrontUp;
    GameObject cam_CloseUp_FrontDown;
    GameObject cam_FullShot_Audience;
    GameObject cam_FullShot_Up;
    GameObject cam_FullShot_Front;
    GameObject cam_FullShot_ArtistRight;
    GameObject cam_FullShot_ArtistLeft;
    GameObject cam_FullShot_Down;

    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponent<PlayerState>();

        camParent = GameObject.Find("CameraParent").transform;
        cam_CloseUp_ArtistRight = camParent.Find("Camera_CloseUp_ArtistRight").gameObject;
        cam_CloseUp_ArtistLeft = camParent.Find("Camera_CloseUp_ArtistLeft").gameObject;
        cam_CloseUp_FrontUp = camParent.Find("Camera_CloseUp_FrontUp").gameObject;
        cam_CloseUp_FrontDown = camParent.Find("Camera_CloseUp_FrontDown").gameObject;
        cam_FullShot_Audience = camParent.Find("Camera_FullShot_Audience").gameObject;
        cam_FullShot_Up = camParent.Find("Camera_FullShot_Up").gameObject;
        cam_FullShot_Front = camParent.Find("Camera_FullShot_Front").gameObject;
        cam_FullShot_ArtistRight = camParent.Find("Camera_FullShot_ArtistRight").gameObject;
        cam_FullShot_ArtistLeft = camParent.Find("Camera_FullShot_ArtistLeft").gameObject;
        cam_FullShot_Down = camParent.Find("Camera_FullShot_Down").gameObject;

        // 카메라 배열
        cameras[0] = cam_Main; 
        cameras[1] = cam_CloseUp_ArtistRight;
        cameras[2] = cam_CloseUp_ArtistLeft;
        cameras[3] = cam_CloseUp_FrontUp;
        cameras[4] = cam_CloseUp_FrontDown;
        cameras[5] = cam_FullShot_Audience;
        cameras[6] = cam_FullShot_Up;
        cameras[7] = cam_FullShot_Front;
        cameras[8] = cam_FullShot_ArtistRight;
        cameras[9] = cam_FullShot_ArtistLeft;
        cameras[10] = cam_FullShot_Down;

        // 시작할 때 카메라 끄기
        for(int i = 1; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }

        //만약에 내것이라면
        if (photonView.IsMine == true)
        {
            //camPos를 활성화 한다.
            camPos.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine == true)
        {
            //1. 마우스의 움직임을 받는다.
            mx = Input.GetAxis("Mouse X");
            my = Input.GetAxis("Mouse Y");

            //2. 마우스이 움직임값으로 회전값을 누적시킨다.
            rotX += mx * rotSpeed * Time.deltaTime;
            rotY += my * rotSpeed * Time.deltaTime;

            //3. 플레어의 회전 y값을 셋팅한다.
            transform.localEulerAngles = new Vector3(0, rotX, 0);
            //4. CamPos의 회전 x값을 셋팅한다.
            camPos.localEulerAngles = new Vector3(-rotY, 0, 0);
        }
        // 카메라 변경
        CameraChange();
    }

    // 숫자버튼을 누르면 카메라 전환하고
    // 이동하면 원래 카메라로 돌아오고 싶다
    public void CameraChange()
    {
        // 움직이면 자기카메라로 항상 돌아오게 하고 싶다
        if(playerState.curState != PlayerState.State.Idle)
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[0].SetActive(true);
            }
        }
        // 1번 누르면 우측 클로즈업 카메라
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            //cam_CloseUp_ArtistRight.SetActive(true);
            //cam_Main.SetActive(false);
            for(int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[1].SetActive(true);
            }
        }
        // 2번 누르면 좌측 클로즈업 카메라
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[2].SetActive(true);
            }
        }
        // 3번 누르면 정면 상단 카메라
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[3].SetActive(true);
            }
        }
        // 4번 누르면 정면 하단 카메라
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[4].SetActive(true);
            }
        }
        // 5번 누르면 객석 비추는 카메라
        if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[5].SetActive(true);
            }
        }
        // 6번 누르면 풀샷 상단 카메라
        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[6].SetActive(true);
            }
        }
        // 7번 누르면 풀샷 정면 카메라
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[7].SetActive(true);
            }
        }
        // 8번 누르면 풀샷 우측 카메라
        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[8].SetActive(true);
            }
        }
        // 9번 누르면 풀샷 우측 카메라
        if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[9].SetActive(true);
            }
        }
        // 0번 누르면 풀샷 정면 하단 카메라
        if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                cameras[i].SetActive(false);
                cameras[10].SetActive(true);
            }
        }
    }
}
