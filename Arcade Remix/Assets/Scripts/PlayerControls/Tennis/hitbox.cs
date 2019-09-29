using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour {

	private SpriteRenderer sr;
	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(1f,1f,1f,.25f); //is about 50% transparent
	}
}
