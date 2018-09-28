using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power : MonoBehaviour {

	// Make a timer
	private float timer = 10.0f;
	public int second = 10;
	public int counter;
	private bool done = false;

	// Update is called once per frame
	void Update () 
	{
		if (second > 0)
		{
			if (Input.GetMouseButtonDown(0))
				counter += 1;

			timer -= Time.deltaTime;
			second = Mathf.RoundToInt(timer);
		}
		else
		{
			if (!done)
			{
				Vector2 test = new Vector2(counter * 2, counter * 2);
				this.gameObject.GetComponent<Rigidbody2D>().AddForce (test, ForceMode2D.Impulse);
				done = true;
			}
		}
	}
}
