using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skiierMovement : MonoBehaviour {

	public float accel;
	public Rigidbody2D rb;
	public float vel;
	public float yVel;

	private float max;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		max = 5;
		yVel = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey(KeyCode.D)) && (vel < max))
		{
			vel += accel;
		}
		if (Input.GetKey(KeyCode.A) && (vel > -max))
		{
			vel -= accel;
		}
		if (transform.position.y > 3f)
			yVel = -.01f;
		else
			yVel = 0f;
		
	}

	void FixedUpdate()
	{
		rb.velocity =
		 new Vector2(vel, yVel);
	}
}
