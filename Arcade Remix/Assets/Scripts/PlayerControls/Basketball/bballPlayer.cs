using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bballPlayer : MonoBehaviour 
{
	public GameObject player;
	public GameObject hoop;
	public float yPos;
	public float ySpeed;
	private float yStart;
	// Use this for initialization
	void Start () 
	{
		yStart = player.GetComponent<Transform>().position.y;
		ySpeed = 2;

	}
	
	// Update is called once per frame
	void Update () 
	{
		yPos = player.GetComponent<Transform>().position.y;
		if (Input.GetMouseButton(0) && (gameObject.transform.position.y < 0))
		{
			if ((yPos + 6) <= gameObject.transform.position.y)
				yPos += ySpeed;
		}
		else
		{
			if (yPos > yStart)
				yPos -= ySpeed;
		}
		if (player.GetComponent<Transform>().position.x >= hoop.GetComponent<Transform>().position.x)
			player.GetComponent<Transform>().localScale = new Vector2(-1, 1);
		else
			player.GetComponent<Transform>().localScale = new Vector2(1, 1);

		player.GetComponent<Transform>().position = new Vector2(gameObject.GetComponent<Transform>().position.x, 
																yPos);
	}
}
