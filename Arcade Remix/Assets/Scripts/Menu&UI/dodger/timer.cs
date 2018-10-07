using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timer : MonoBehaviour
{
	public Text txtTime;
	private int second = 0;
	private float time = 0;
	private bool changed = false;

	// variables to increase difficulty
	public int secondToIncDiff;
	public float changeFloat = 2;

	// Use this for initialization
	void Start () 
	{
		txtTime.text = second.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
		second = Mathf.RoundToInt(time);
		txtTime.text = second.ToString();

		// Control the frequency of spawner based on time
		if (second % secondToIncDiff == 0)
		{
			if (second != 0)
				if (!changed)
				{
					spawner ballScript = GetComponent<spawner>();
					ballScript.frequency += changeFloat;
					changed = true;						
				}

		}
		else
			changed = false;
	}
}
