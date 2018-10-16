using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {

	public bool hasLanded;
	private float travelDistance;
	public bool goingHorizontal = true;

	public Vector2 pointA;
	public Vector2 pointB;

	public GameObject playah;

	void Start()
	{
		travelDistance = Random.Range(1f, 2f);
		hasLanded = false;
		pointA = transform.position;
		pointB = new Vector2 (pointA.x + travelDistance, pointA.y);
	}

	void Update()
	{
		if(!hasLanded)
		{
			if (goingHorizontal)
			{
				transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
			}
		}

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		hasLanded = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
			teleportPlatform();
			hasLanded = false;
	}

	void teleportPlatform()
	{
		transform.position = new Vector2(playah.transform.position.x + 25f, Random.Range(-5.5f, 5.5f));
		travelDistance = Random.Range(1f, 2f);
		pointA = transform.position;
		pointB = new Vector2 (pointA.x + travelDistance, pointA.y);
	}
}

