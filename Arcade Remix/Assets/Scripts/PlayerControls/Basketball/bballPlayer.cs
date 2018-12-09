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

	private Animator anim;

	public float throwCounter;
	public float throwCounterLim;


	// Use this for initialization
	void Start () 
	{
		yStart = player.GetComponent<Transform>().position.y;
		ySpeed = 2;
		anim = player.GetComponent<Animator>();
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
		//anim.Play("bball anim_bball_moving", -1, 0f);
		if (Input.GetMouseButton(0))
		{
			anim.Play("anim_bball_locked", -1, 1f);
			throwCounter = throwCounterLim;
		}
		else
		{
			
			
			if (throwCounter <= 0f)
				anim.Play("anim_bball_move", 0, 1f);
			else
			{
				throwCounter -= .05f;
				anim.Play("anim_bball_throw", 0, 1f);
			}
		}


		if (player.GetComponent<Transform>().position.x >= hoop.GetComponent<Transform>().position.x)
			player.GetComponent<Transform>().localScale = new Vector2(-1, 1);
		else
			player.GetComponent<Transform>().localScale = new Vector2(1, 1);

		player.GetComponent<Transform>().position = new Vector2(gameObject.GetComponent<Transform>().position.x, 
																yPos);
	}
}
