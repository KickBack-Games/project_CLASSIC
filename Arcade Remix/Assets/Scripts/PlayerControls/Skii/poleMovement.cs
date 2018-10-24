using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleMovement : MonoBehaviour {

	public GameObject skiier;
	public float speed;
	private float xSpawn = 2;
	public float ySpawn;

	// Use this for initialization
	void Start () 
	{
		// Randomize initial x pos
		transform.position = new Vector2(Random.Range(-xSpawn, xSpawn), transform.position.y);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.up * Time.deltaTime * speed);

		// Reset position if 'y' amount above player.y
		if (transform.position.y >= skiier.transform.position.y + 5f)
		{
			transform.position = new Vector2(Random.Range(-xSpawn, xSpawn), skiier.transform.position.y - 15);
		}
	}
}
