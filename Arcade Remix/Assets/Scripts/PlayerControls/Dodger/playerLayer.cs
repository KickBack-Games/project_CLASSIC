using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLayer : MonoBehaviour {

	private float sortingF;
	private int sortingI;
	private SpriteRenderer spr;
	public playerMovement pm;
	
	// Use this for initialization
	void Start () 
	{
		spr = GetComponent<SpriteRenderer>();
		pm = GetComponent<playerMovement>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (pm.lost)
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
