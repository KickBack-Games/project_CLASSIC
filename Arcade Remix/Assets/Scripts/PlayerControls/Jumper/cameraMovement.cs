using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public GameObject followPlayer;
	public float offset;

	private Vector2 temp = new Vector2();

	// Update is called once per frame
	void Update () {
		temp = followPlayer.gameObject.GetComponent<Transform>().position;
		this.gameObject.GetComponent<Transform>().position = new Vector3(temp.x + offset, 0, -10);
	}
}
