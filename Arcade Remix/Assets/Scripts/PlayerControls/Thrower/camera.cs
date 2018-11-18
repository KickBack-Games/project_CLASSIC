using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public GameObject objToFollow;

	private Vector2 temp = new Vector2();

	public float xRan;
	public float yRan;

	// Update is called once per frame
	void Update () 
	{

		int sec = objToFollow.GetComponent<power>().second;
		if (sec > 0)
		{
			if(Input.GetMouseButtonDown(0))
			{
				this.gameObject.GetComponent<Transform>().position = new Vector2(Random.Range(-xRan, xRan), 
																				 Random.Range(-yRan + 2.67f, yRan + 2.67f));
			}
			else
			this.gameObject.GetComponent<Transform>().position = new Vector2(0, 2.67f);

		}
		else
		{
			// As long as the ball hasn't landed... follow the ball.. then stop
			if (!objToFollow.GetComponent<power>().landed)
			{
				temp = objToFollow.gameObject.GetComponent<Transform>().position;
				this.gameObject.GetComponent<Transform>().position = new Vector2(temp.x, 2.67f);
			}
		}
	}
}
