using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class power : MonoBehaviour {

	// Make a timer
	public float timer = 10.0f;
	public int second;

	public float counter = 0;
	private bool done = false;
	public bool landed = false;
	public SpriteRenderer sr;

	// Text
	public Text txtTime;
	public Text txtDistance; 
	public float distance;

	public GameObject pre_particles;
	public GameObject feedback;
	public GameObject holder;

    public Image bar;

    public int[] goals;
    public Text goalText;
    public Text timeText;
    public GameObject results;
    public int secs;

    void Start ()
	{
		setText();
		sr = GetComponent<SpriteRenderer>();
        bar.fillAmount = 0;
        scr_game_launcher.winstate = -1;
        goalText.text = "Tap " + goals[global.difficulty - 1] + " Times!";
        results.GetComponent<scr_ui_results>().next = "scn_title";
    }

	// Update is called once per frame
	void Update () 
	{
        global.goalCounter = second;
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            global.scoreThrower += 50;
        }
		if (second > 0)
		{
			if (Input.GetMouseButtonDown(0))
			{

				Vector3 mousePos = Input.mousePosition;
				mousePos = Camera.main.ScreenToWorldPoint(mousePos);
				counter += 1;
				Instantiate(feedback, mousePos, Quaternion.identity);
                bar.fillAmount = counter / 40;
            }

			timer -= Time.deltaTime;
			second = Mathf.RoundToInt(timer);
			setText();
		}
		else
		{
            if (counter >= 30)
            {
                scr_game_launcher.winstate = 1;
            }
            else
            {
                scr_game_launcher.winstate = -1;
            }
            if (!done)
			{
				//counter = counter * 10; //For testing purposes
				Vector2 supahPOWAH = new Vector2(counter * 5, counter * 5);
				this.gameObject.GetComponent<Rigidbody2D>().AddForce (supahPOWAH, ForceMode2D.Impulse);
				// Time is redundant now in screen, so change it so that we show total taps instead
				txtTime.text = counter.ToString();
				done = true;
				sr.sortingOrder = 5;
				Destroy(holder);
			}
			else
				if (!landed)
					txtDistance.text = (Mathf.FloorToInt(gameObject.GetComponent<Transform>().position.x)).ToString() + " m";
			
		}
	
	}

	void setText()
	{
		txtDistance.text = counter.ToString();
		txtTime.text = second.ToString();

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "RunnerBlock")
			landed = true;
	}
}
