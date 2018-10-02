using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class power : MonoBehaviour {

	// Make a timer
	private float timer = 10.0f;
	public int second = 10;

	public int counter = 0;
	private bool done = false;

	// Text
	public Text txtTime;
	public Text txtDistance; 
	public float distance;

	public GameObject pre_particles;

	void Start ()
	{
		setText();
	}

	// Update is called once per frame
	void Update () 
	{
		if (second > 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				counter += 1;

				// Create particles
				for (int i = 0; i < 10; i++)
					Instantiate(pre_particles, this.gameObject.GetComponent<Transform>());
			}

			timer -= Time.deltaTime;
			second = Mathf.RoundToInt(timer);
			setText();
		}
		else
		{
			if (!done)
			{
				Vector2 supahPOWAH = new Vector2(counter * 3, counter * 3);
				this.gameObject.GetComponent<Rigidbody2D>().AddForce (supahPOWAH, ForceMode2D.Impulse);
				// Time is redundant now in screen, so change it so that we show total taps instead
				txtTime.text = counter.ToString();
				done = true;
			}
			else
			{

				txtDistance.text = (Mathf.FloorToInt(gameObject.GetComponent<Transform>().position.x)).ToString() + " m";
			}
		}
	
	}

	void setText()
	{
		txtDistance.text = counter.ToString();
		txtTime.text = second.ToString();

	}
}
