using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("가속도")]
    public float accel;
    [Header("최대 속도")]
    public float maxSpeed;
    [Header("Shift 시 속도 배수")]
    public float boostFactor;
    [Header("회전 속도")]
    public float rotSpeed;
    [Header("X축 최대 회전각")]
    public float maxRotX;

    float speed;
    float o_accel;
    float o_maxSpeed;
    float rotX;
    float rotY;

    void Start()
    {
        o_accel = accel;
        o_maxSpeed = maxSpeed;

        rotX = -transform.eulerAngles.x;
        rotY = transform.eulerAngles.y;
    }

    void Update()
    {
        PlaceableObject po = GetComponent<PlaceableObject>();

        if (po != null && po != BuildingSystem.Instance.objectToPlace)
            return;

        // 우클릭을 누르고 있을 때만 움직일 수 있다
        if (Input.GetMouseButton(1) == false)
            return;

        // 왼쪽 Shift 를 누르고 있는 동안 속도가 빨라진다
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= boostFactor;
            accel = o_accel * boostFactor;
            maxSpeed = o_maxSpeed * boostFactor;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= boostFactor;
            accel = o_accel;
            maxSpeed = o_maxSpeed;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float ud = Input.GetAxis("UpDown");

        Vector3 dir = new Vector3(h, ud, v);

        if (dir.magnitude == 0)
            speed = 0;
        else
            speed = Mathf.Clamp(speed + accel * Time.deltaTime, 0, maxSpeed);

        transform.position += transform.TransformDirection(Vector3.ClampMagnitude(dir, 1f)) * speed * Time.deltaTime;

        rotY += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        rotX += Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -maxRotX, maxRotX);

        transform.eulerAngles = new Vector3(-rotX, rotY, 0);
    }
}
