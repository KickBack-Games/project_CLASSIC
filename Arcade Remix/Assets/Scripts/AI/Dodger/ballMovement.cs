using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour {


	public float speed;
	public int dir;

	void Start()
	{
		dir = Random.Range(0, 4);
	}

	// Update is called once per frame
	void Update () 
	{
		// Move the object forward along its z axis 1 unit/second.
		if (dir == 0) // UP
        	transform.Translate(0, Time.deltaTime * speed, 0);
        else if(dir == 1) // DOWN
        	transform.Translate(0, Time.deltaTime * -speed, 0);
        else if(dir == 2) // RIGHT
        	transform.Translate(Time.deltaTime * speed, 0, 0);
        else if(dir == 3) // LEFT
        	transform.Translate(Time.deltaTime * -speed, 0, 0);

        
	}

}

