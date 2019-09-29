using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public GameObject ball;
	public Vector2 pos;

	public float posToAdd;

	public float posX;
	public float parPos;
	
	// Update is called once per frame
	void Update () {
		pos = ball.GetComponent<Transform>().position;
		posX = pos.x;
		if(pos.x > parPos)
		{
			Vector2 temp = this.gameObject.GetComponent<Transform>().position;
			temp.x += posToAdd;
			this.gameObject.GetComponent<Transform>().position = temp;
			parPos *= 3;
		}
	}
}
