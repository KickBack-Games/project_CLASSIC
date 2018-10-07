using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour 
{
	public float frequency; 
	public float counter;

	public GameObject ball;
	// Update is called once per frame
	void Update () 
	{
		counter -= frequency;
		if (counter <= 0.0)
		{
			Instantiate(ball);
			counter = 10; 
		}
	}
}
