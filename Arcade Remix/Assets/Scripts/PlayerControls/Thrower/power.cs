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
	public SpriteRenderer sr;

	// Text
	public Text txtTime;
	public Text txtDistance; 
	public float distance;

	public GameObject pre_particles;
	public GameObject feedback;
	public GameObject holder;
	void Start ()
	{
		setText();
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (second > 0)
		{
			if (Input.GetMouseButtonDown(0))
			{

				Vector3 mousePos = Input.mousePosition;
				mousePos = Camera.main.ScreenToWorldPoint(mousePos);
				counter += 1;
				Instantiate(feedback, mousePos, Quaternion.identity);
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
				sr.sortingOrder = 5;
				Destroy(holder);
			}
			else
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
		Vector2 supahPOWAH = new Vector2(counter * 2.9f, counter * 2.9f);
		this.gameObject.GetComponent<Rigidbody2D>().AddForce (-supahPOWAH, ForceMode2D.Impulse);
	}
}
