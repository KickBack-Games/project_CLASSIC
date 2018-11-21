using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tennisBall : MonoBehaviour {

	private Vector2 pos;
	public float speed;

	public bool swung;
	public bool goingup;
	private Vector3 mPos;

	// Use this for initialization
	void Start () 
	{
		goingup = false;
		pos = new Vector2(Random.Range(-3f, 3f), -5f);
		mPos.z = 10;
	}
	
	// Update is called once per frame
	void Update () 
	{
   		 // select distance = 10 units from the camera
		mPos = Input.mousePosition;
		mPos.z = 10;
		mPos = Camera.main.ScreenToWorldPoint(mPos);
		if (!goingup)
		{
			if (Input.GetMouseButtonDown(0)) 
			{

				if ((transform.position.y < -2.4f) && 
					(transform.position.y > -4.8f) &&
					(mPos.y < -2.4f) &&
					(mPos.y > -4.8f) && 
					(!swung))
				{
						// LEFT SIDE OF THE HITBOX
					if ((transform.position.x < -1.08f) &&
						(transform.position.x > -3.3f) && 
						(mPos.x < -1.08f) &&
						(mPos.x > -3.35f))
					{
						pos = new Vector2(Random.Range(-3f, 3f), 5f);
						global.scoreTennis += 250;
						goingup = true;
					}
						//  MIDDLE SIDE OF THE HITBOX
					else if ((transform.position.x <= 1.08f) &&
						(transform.position.x >= -1.08f) && 
						(mPos.x <= 1.08f) &&
						(mPos.x >= -1.08f))
					{
						pos = new Vector2(Random.Range(-3f, 3f), 5f);
						global.scoreTennis += 250;
						goingup = true;
					}
						// RIGHT SIDE OF THE HITBOX
					else if ((transform.position.x < 3.3f) &&
						(transform.position.x > 1.08f) && 
						(mPos.x < 3.3f) &&
						(mPos.x > 1.08f))
					{
						pos = new Vector2(Random.Range(-3f, 3f), 5f);
						global.scoreTennis += 250;
						goingup = true;
					}
					swung = true;
				}
			}
		}

		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		if (Input.GetKeyDown(KeyCode.R) || transform.position.y >= 4.8f || transform.position.y <= -4.8f)
			SceneManager.LoadScene("scn_game_tennis");
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.tag == "bad") // For the opponents hitbox
		{
			pos = new Vector2(Random.Range(-3f, 3f), -5f);
			goingup = false;
			swung = false;
			if (speed < 12)
				speed += .25f;
		}
	}
}


