using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class confettiMaker : MonoBehaviour {

	public bool scored = false;
	public float makeTime;
	public float freq;

	public GameObject confetti_;
	public GameObject board;
	public Rigidbody2D ballRB;

	public Text txtScore; 
	private bool transitioning;
	private float trFloat = 0f;


    private void Start()
    {
        scr_game_launcher.winstate = -1;
    }
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

		// IF SCORED THEN YOU CAN TRANSITION TO NEW POSITION!
		if (transitioning)
		{
			trFloat += .05f;
			if (trFloat >= 1f)
			{
				board.transform.position = new Vector2(Random.Range(-9f, 9f), Random.Range(0f, 15f));
				transitioning = false;
				trFloat = 0;
			}
			// BACK TO NORMAL
			
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.name == "Ball")
        {
            global.scoreBasketball += 500;
            global.goalCounter++;
            scored = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            testShot.points++;

            // Change the position of the board and all that it "childs"
            // transition time.
            transitioning = true;
        }
	}

}
