using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testShot : MonoBehaviour {

	public bool dragging = false;
	public bool impulseGiven = false;
	public float maxVelocity;

	public Rigidbody2D rb;
	private Vector2 test;

	// Update is called once per frame
	void Update () 
	{
		// if clicked mouse, then drag
		//GetComponent<Rigidbody2D>().gravityScale = 10;
		if (dragging)
		{
			if (impulseGiven)
			{
				Vector2 supahPOWAH = new Vector2(0, 300);
				gameObject.GetComponent<Rigidbody2D>().AddForce (supahPOWAH, ForceMode2D.Impulse);
				gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
				impulseGiven = false;
			}
			rb.position = test;
		}

	}

	void FixedUpdate()
	{
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
	}


	void OnMouseDown()
	{
		test = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//isPressed = true;
		//rb.isKinematic = true;
		dragging = true;
		gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
	}

	void OnMouseUp()
	{
	
		//isPressed = false;
		//rb.isKinematic = false;
		dragging = false;
		impulseGiven = true;

	}
}
