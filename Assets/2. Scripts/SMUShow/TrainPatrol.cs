using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPatrol : MonoBehaviour
{
	public enum Mode
	{
		PingPong	= 1 << 0,
		Repeat		= 1 << 1
	}

    public Transform startPosition;
    public Transform endPosition;
	public float speed;
	public Mode mode;

    void Start() { }

    void Update()
    {
		Vector3 dir = endPosition.position - startPosition.position;

		transform.position = startPosition.position + dir.normalized * Point(Time.time * speed, dir.magnitude);
    }

	float Point(float t, float length)
	{
		float value = 0;

		switch(mode)
		{
			case Mode.PingPong :	value = Mathf.PingPong(t, length);
				break;
			case Mode.Repeat :		value = Mathf.Repeat(t, length);
				break;
		}

		return value;
	}
}
