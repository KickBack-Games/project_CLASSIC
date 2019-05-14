using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetButton : MonoBehaviour {

	private SpriteRenderer sr;
	private Vector3 mPos;

	// Use this for initialization
	void Start () 
	{
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(1f,1f,1f,.45f); //is about 50% transparent
	}
}
