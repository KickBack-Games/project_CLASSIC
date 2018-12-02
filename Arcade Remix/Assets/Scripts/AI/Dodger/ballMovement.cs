using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour {


	public float speed;
	public int dir;
	private float sortingF;
	private int sortingI;

	void Start()
	{
		dir = Random.Range(0, 4);
		int[] gridX = new int[] {-2, -1, 0, 1, 2};
		int[] gridY = new int[] {-4, -3, -2, -1, 0, 1, 2};

		// Starting position.
		if (dir == 0) // UP
        	transform.position = new Vector2(gridX[Random.Range(0, gridX.Length)], -7.0f);
        else if(dir == 1) // DOWN
        	transform.position = new Vector2(gridX[Random.Range(0, gridX.Length)], 6.0f);
        else if(dir == 2) // RIGHT
        	transform.position = new Vector2(-4.75f, gridY[Random.Range(0, gridY.Length)]);
        else if(dir == 3) // LEFT
        	transform.position = new Vector2(4.75f, gridY[Random.Range(0, gridY.Length)]);
        
	}

	// Update is called once per frame
	void Update () 
	{
		// This will allow a "3D" effect by keeping the sorting layer based on height
		// This effect interacts with the player when the ball is about to hit top or bottom of player
		SpriteRenderer spr = GetComponent<SpriteRenderer>();
		sortingF = gameObject.transform.position.y;
		sortingI = Mathf.RoundToInt(sortingF);

		spr.sortingOrder = sortingI * -1;

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

