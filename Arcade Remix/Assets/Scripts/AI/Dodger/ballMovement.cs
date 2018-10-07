using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour {


	public float speed;
	public int dir;

	void Start()
	{
		dir = Random.Range(0, 4);
		int[] gridX = new int[] {-2, -1, 0, 1, 2};
		int[] gridY = new int[] {-3, -2, -1, 0, 1, 2, 3};

		// Starting position.
		if (dir == 0) // UP
        	transform.position = new Vector2(gridX[Random.Range(0, gridX.Length)], -7.0f);
        else if(dir == 1) // DOWN
        	transform.position = new Vector2(gridX[Random.Range(0, gridX.Length)], 7.0f);
        else if(dir == 2) // RIGHT
        	transform.position = new Vector2(-4.0f, gridY[Random.Range(0, gridY.Length)]);
        else if(dir == 3) // LEFT
        	transform.position = new Vector2(4.0f, gridY[Random.Range(0, gridY.Length)]);
        
	}

	// Update is called once per frame
	void Update () 
	{
		// Move the object forward along its correct axis.
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

