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
		if (other.gameObject.tag == "Respawn")
		{
			teleportPlatform();
			hasLanded = false;
		}
	}

	void teleportPlatform()
	{
		int hori = Random.Range(0,2);

		transform.position = new Vector2(playah.transform.position.x + 25f, Random.Range(-5.5f, 5.5f));
		travelDistance = Random.Range(1f, 3f);
		pointA = transform.position;
		if (hori == 0)
			pointB = new Vector2 (pointA.x + travelDistance, pointA.y);
		else
			pointB = new Vector2(pointA.x, pointA.y + travelDistance);
	}
}

