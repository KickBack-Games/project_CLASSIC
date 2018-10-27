using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tennisBall : MonoBehaviour {

	private Vector2 pos;
	public float speed;
	public bool goingup;

	// Use this for initialization
	void Start () 
	{
		goingup = false;
		pos = new Vector2(Random.Range(-3f, 3f), -5f);

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene("scn_game_tennis");

		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
	}


	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player") // coming down
		{
			if (!goingup)
			{
				if (transform.position.x <= -1.06) // Left
				{
					if (Input.GetKeyDown(KeyCode.A))
					{
						pos = new Vector2(Random.Range(-3f, 3f), 5f);
						goingup = true;
					}
				}
				if (transform.position.x >= 1.06) // Right
				{
					if (Input.GetKeyDown(KeyCode.D))
					{
						pos = new Vector2(Random.Range(-3f, 3f), 5f);
						goingup = true;
					}
				}
				if ((transform.position.x < 1.06) && (transform.position.x > -1.06)) // middle trajectory
				{
					if (Input.GetKeyDown(KeyCode.W))
					{
						pos = new Vector2(Random.Range(-3f, 3f), 5f);
						goingup = true;
					}
				}
			}
		}
		else if(other.gameObject.tag == "bad") // For the opponents hitbox
		{
			pos = new Vector2(Random.Range(-3f, 3f), -5f);
			goingup = false;
		}
	}
}


