using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class power : MonoBehaviour {
	private bool done = false;
	public bool landed = false;
	public SpriteRenderer sr;

	public float distance;

	public GameObject pre_particles;
	public GameObject feedback;
	public GameObject holder;

    public Image bar;

    public GameObject results;

    public GameObject eventsystem;

    void Start ()
	{
		sr = GetComponent<SpriteRenderer>();
        bar.fillAmount = 0;
        global.goalCounter = 0;
    }

	// Update is called once per frame
	void Update () 
	{
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            global.scoreThrower += 10;
        }
		if (global.timeSec > 0)
		{
			if (Input.GetMouseButtonDown(0))
			{

				Vector3 mousePos = Input.mousePosition;
				mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                global.goalCounter++;
				Instantiate(feedback, mousePos, Quaternion.identity);
                bar.fillAmount = global.goalCounter / 10;
            }
		}
        if (global.goalCounter>=10)
        {
            eventsystem.GetComponent<scr_game_timer>().enabled = false;
            if (!done)
			{
				Vector2 supahPOWAH = new Vector2(global.goalCounter * 8, global.goalCounter * 8);
				this.gameObject.GetComponent<Rigidbody2D>().AddForce (supahPOWAH, ForceMode2D.Impulse);
				// Time is redundant now in screen, so change it so that we show total taps instead
				//txtTime.text = counter.ToString();
				done = true;
				sr.sortingOrder = 5;
				Destroy(holder);
			}			
		}
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "RunnerBlock")
        {
            landed = true;
            global.winner = true;
            results.SetActive(true);
        }
    }
}
