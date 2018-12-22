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
	private float offset; 

	private Animator anim;

	public float throwCounter;
	public float throwCounterLim;

	public bool caught;
	private bool jumped;
	public float jumpPow;

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
		caught = GetComponent<testShot>().touching;
        anim.SetFloat("speed",Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x)/50);
        yPos = player.GetComponent<Transform>().position.y;
		//anim.Play("bball anim_bball_moving", -1, 0f);
		if (Input.GetMouseButton(0))
		{
			anim.Play("anim_bball_locked");
			throwCounter = throwCounterLim;
			jumped = false;
		}
		else
		{
			if (caught || (this.GetComponent<Rigidbody2D>().velocity.x < 0.02f  && this.GetComponent<Rigidbody2D>().velocity.x > -.02f))
			{
				anim.Play("anim_bball_idle");
			}
			else
			{
				if (throwCounter <= 0f)
				{
					anim.Play("anim_bball_moving");
				}
				else
				{
					throwCounter -= .05f;
					anim.Play("anim_bball_throw");
					print(throwCounter);
				}
			}


			if (!jumped)
			{
				jumpPow = .2f;
				jumped = true;
			}
		}
		if ((player.GetComponent<Transform>().position.y > yStart))
		{
			jumpPow -= .01f;
		}
		else if ((player.GetComponent<Transform>().position.y < yStart - .05f))
			jumpPow = 0;


		if (player.GetComponent<Transform>().position.x >= hoop.GetComponent<Transform>().position.x)
		{
			offset = 2;
			player.GetComponent<Transform>().localScale = new Vector2(-1, 1);
		}
		else
		{
			offset = -2;
			player.GetComponent<Transform>().localScale = new Vector2(1, 1);
		}

		player.GetComponent<Transform>().position = new Vector2(gameObject.GetComponent<Transform>().position.x + offset, 
																yPos);
	}

}