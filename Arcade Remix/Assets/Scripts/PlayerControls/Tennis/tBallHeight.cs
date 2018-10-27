using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tBallHeight : MonoBehaviour {

	private tennisBall tb;
	private float LSx;
	private float LSy;
	private bool heightGoingDown;
	// Use this for initialization
	void Start () 
	{
		tb = GetComponent<tennisBall>();
		LSx = 2.5f;
		LSy = 2.5f;
		heightGoingDown = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		LSx = (1/Mathf.Abs(transform.position.y) + 2f) + 2f;
		LSy = (1/Mathf.Abs(transform.position.y) + 2f) + 2f;

		if (LSx > 4.6f && LSy > 4.6f)
		{ 

			LSx = 4.6f;
			LSy = 4.6f;
		}
		transform.localScale = new Vector2(LSx, LSy);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "point")
		{
			heightGoingDown = true;
		}

		if (other.gameObject.tag == "bad")
		{
			heightGoingDown = false;
		}

	}
}
