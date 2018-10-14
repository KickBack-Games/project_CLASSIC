using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confettiMaker : MonoBehaviour {

	public bool scored = false;
	public float makeTime;
	public float freq;
	public GameObject confetti_;

	public GameObject ballGO;
	private int score = 0;

	// Update is called once per frame
	void Update () 
	{
		// NO CHEATING ALLOWED
		if (ballGO.transform.position.y < gameObject.transform.position.y)
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
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		score++;
		print(score);
		scored = true;
		gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
	}

}
