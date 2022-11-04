using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooter : MonoBehaviourPun
{
    public Transform m_start; // 출발 지점.
    Transform m_target; // 도착 지점.

    [Header("미사일 기능 관련")]
    public float m_speed = 2; // 미사일 속도.
    [Space(10f)]
    public float m_distanceFromStart = 6.0f; // 시작 지점을 기준으로 얼마나 꺾일지.
    public float m_distanceFromEnd = 3.0f; // 도착 지점을 기준으로 얼마나 꺾일지.
    [Space(10f)]
    public int m_shotCount = 1; // 총 몇 개 발사할건지.
    [Range(0, 1)] public float m_interval = 0.15f;
    public int m_shotCountEveryInterval = 2; // 한번에 몇 개씩 발사할건지.

    private void Update()
    {
        if (photonView.IsMine == false) return;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            m_target = GameObject.Find("endPos").transform;
            StartCoroutine(CreateMissile());
        }
    }

    public void ShootObjectBtn()
    {
        StartCoroutine(CreateMissile());
    }

    IEnumerator CreateMissile()
    {
        int _shotCount = m_shotCount;
        while (_shotCount > 0)
        {
            for (int i = 0; i < m_shotCountEveryInterval; i++)
            {
                if (_shotCount > 0)
                {
                    //GameObject missile = Instantiate(m_missilePrefab);
                    GameObject missile = PhotonNetwork.Instantiate("PumpingHeart",m_start.position,Quaternion.identity);
                    //missile.GetComponent<BezierMissile>().Init(m_start.transform, m_target.transform, m_speed, m_distanceFromStart, m_distanceFromEnd);
                    missile.GetComponent<FlyingEmotion>().Initialize(m_start, m_target);

                    _shotCount--;
                }
            }
            yield return new WaitForSeconds(m_interval);
        }
        yield return null;
    }
}