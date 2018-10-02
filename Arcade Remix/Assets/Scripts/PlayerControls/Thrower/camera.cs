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
																				 Random.Range(-yRan, yRan));
			}
			else
			this.gameObject.GetComponent<Transform>().position = new Vector2(0, 0);

		}
		else
		{

			temp = objToFollow.gameObject.GetComponent<Transform>().position;
			this.gameObject.GetComponent<Transform>().position = new Vector2(temp.x, 0);
		}
	}
}
