using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skiierMovement : MonoBehaviour {

	public float accel;
	public Rigidbody2D rb;
	public float vel;
	public float yVel;

	private float max;

	public Text txtScore; 
	public int boundary;

	private Vector3 mPos;

    public static int goals;
	
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		max = 4;
		yVel = 0;
		mPos.z = 10;
        goals = 0;
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(0);
        scr_game_launcher.winstate = -1;
    }
	
	// Update is called once per frame
	void Update () 
	{
		mPos = Input.mousePosition;
		mPos.z = 10;
		mPos = Camera.main.ScreenToWorldPoint(mPos);
		if (Input.GetMouseButton(0))
		{
			if ((mPos.x > 0) && (vel < max))
			{
				vel += accel;
			}
			if ((mPos.x) <= 0 && (vel > -max))
			{
				vel -= accel;
			}
		}
		else
		{
			
			if (vel == 0)
				vel = 0;
			else if ((vel < 0))
				vel += .05f;
			else if ((vel > 0))
				vel -= .05f;
			

		}
		if (transform.position.y > 3f)
			yVel = -.01f;
		else
			yVel = 0f;

	}

	void FixedUpdate()
	{
		rb.velocity =
		 new Vector2(vel, yVel);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        global.scoreSkii += 500;
        goals++;
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(goals);
        if (goals >= 3)
        {
            scr_game_launcher.winstate = 1;
        }
    }
}
