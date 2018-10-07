using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour 
{

	private float speed = 7.0f;
	private Vector3 pos;
	private Transform tr;

	private bool lost;

	void Start() 
	{
		pos = transform.position;
		tr = transform;
		lost = false;
	}

	void Update() 
	{

		// Check to see if the player lost
		if ((pos.x >= 3) || 
			(pos.x <= -3) ||
			(pos.y >= 5) ||
			(pos.y <= -5))
			lost = true;

		if (lost)
		{
			transform.Rotate( new Vector3(0, 0, 300) * Time.deltaTime);
			// falling effect
			if (transform.localScale.x >= 0 && transform.localScale.y >= 0)
				transform.localScale -= new Vector3(0.01f, 0.01f, 0.0f);
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.D) && tr.position == pos)
			{
				pos += Vector3.right;
			}
			else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos) 
			{
				pos += Vector3.left;
			}
			else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos) 
			{
				pos += Vector3.up;
			}
			else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos) 
			{
				pos += Vector3.down;
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
	}   

	// HANDLE THE COLLISION HERE
    void OnTriggerEnter2D(Collider2D other)
    {
    	if (!lost)
    	{
	    	ballMovement ballScript = other.GetComponent<ballMovement>();
	    	int dir = ballScript.dir;

	        if (other.gameObject.tag == "ball")
	    	{
	    		Destroy(other.gameObject);
	    		if (dir == 0)
	    			pos += Vector3.up * 2;
	            else if (dir == 1)
	            	pos += Vector3.down * 2;
	            else if (dir == 2)
	            	pos += Vector3.right * 2;
	            else
	            	pos += Vector3.left * 2;
	        }
    	}
    }
}
