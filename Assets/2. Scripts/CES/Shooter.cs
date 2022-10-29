using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject m_missilePrefab; // �̻��� ������.
    public Transform m_start; // ��� ����.
    public Transform m_target; // ���� ����.

    [Header("�̻��� ��� ����")]
    public float m_speed = 2; // �̻��� �ӵ�.
    [Space(10f)]
    public float m_distanceFromStart = 6.0f; // ���� ������ �������� �󸶳� ������.
    public float m_distanceFromEnd = 3.0f; // ���� ������ �������� �󸶳� ������.
    [Space(10f)]
    public int m_shotCount = 12; // �� �� �� �߻��Ұ���.
    [Range(0, 1)] public float m_interval = 0.15f;
    public int m_shotCountEveryInterval = 2; // �ѹ��� �� ���� �߻��Ұ���.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
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
                    GameObject missile = Instantiate(m_missilePrefab);
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