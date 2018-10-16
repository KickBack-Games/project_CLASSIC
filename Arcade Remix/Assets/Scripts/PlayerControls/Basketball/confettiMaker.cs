using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class confettiMaker : MonoBehaviour {

	public bool scored = false;
	public float makeTime;
	public float freq;

	public GameObject confetti_;
	public GameObject board;
	public Rigidbody2D ballRB;

	private int score = 0;
	public Text txtScore; 
	private bool transitioning;
	private float trFloat = 0f;


	// Update is called once per frame
	void Update () 
	{
		// NO CHEATING ALLOWED
		if (ballRB.velocity.y > 0)
			gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
		else
			gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

		if (scored)
		{
			makeTime += freq;
			if (makeTime <= 1)
			{
				for(int i = 0; i < 5; i++)
					Instantiate(confetti_, gameObject.transform);
				
			}
			else
			{
				scored = false;
				makeTime = 0;
			}
		}

		// DISPLAY SCORE
		txtScore.text = score.ToString();

		// IF SCORED THEN YOU CAN TRANSITION TO NEW POSITION!
		if (transitioning)
		{
			trFloat += .05f;
			if (trFloat >= 1f)
			{
				board.transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(0f, 15f));
				transitioning = false;
				trFloat = 0;
			}

			// BACK TO NORMAL
			
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		score++;
		print(score);
		scored = true;
		gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

		// Change the position of the board and all that it "childs"
		// transition time.
		transitioning = true;
	}

}
