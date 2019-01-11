using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_dodger_tapper : MonoBehaviour {

	private SpriteRenderer sr;
	private float sprT;
	// Use this for initialization
	void Start () 
	{
		sprT = .6f;
		sr = GetComponent<SpriteRenderer>();
		 //is about 50% transparent
		sr.sortingOrder = -998;
	}
	void Update()
	{
		if (sprT >= .13f)
			sprT -= .002f;
		else
			sr.sortingOrder = -1000;

		
		sr.color = new Color(1f,1f,1f,sprT);
	}
}
