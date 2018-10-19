using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMovement : MonoBehaviour 
{

	public GameObject player;
	private Rigidbody2D rb;
	public float speed;
	public float close;
	public float mid;
	public float far;
	public float NEPTUNEPOWER;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		speed = 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x)) > far)
		{
			speed = 100;
		}
		else if ((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x)) > mid)
		{
			speed = 50;
		}
		else if ((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x)) > close)
		{
			speed = 10;
		}
		// Keep speed up
		rb.velocity = new Vector2(Time.deltaTime * speed * NEPTUNEPOWER, 0f);	
		print((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x)));
	}
}
