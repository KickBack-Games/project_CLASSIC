using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public GameObject objToFollow;
	private Vector2 temp = new Vector2();
	// Update is called once per frame
	void Update () 
	{
		temp = objToFollow.gameObject.GetComponent<Transform>().position;
		this.gameObject.GetComponent<Transform>().position = new Vector2(temp.x, this.gameObject.GetComponent<Transform>().position.y);
	}
}
