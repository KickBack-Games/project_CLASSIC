using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLayer : MonoBehaviour {

	private float sortingF;
	private int sortingI;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerMovement s = GetComponent<playerMovement>();
		SpriteRenderer spr = GetComponent<SpriteRenderer>();

		if (s.lost)
		{
			spr.sortingOrder = -50;
		}
		else
		{
			sortingF = gameObject.transform.position.y;
			sortingI = Mathf.RoundToInt(sortingF);
			spr.sortingOrder = sortingI * -1;
		}
	}
}
