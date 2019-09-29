using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour 
{
	public float xSpeed;
	public float ySpeed;
	public int lifetime;

	// Use this for initialization
	void Start () {
		xSpeed = Random.Range(-xSpeed, xSpeed);
		ySpeed = Random.Range(-ySpeed, ySpeed);
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<Transform>().Translate(Vector2.right * Time.deltaTime * xSpeed);
		this.gameObject.GetComponent<Transform>().Translate(Vector2.up * Time.deltaTime * ySpeed);
		// Make it disappear
		lifetime -= 1;
		if(lifetime <= 0)
			Destroy(this.gameObject);
	}
}
