using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveMovement : MonoBehaviour 
{

	public GameObject player;
	public float speed;
	public float close;
	public float mid;
	public float far;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x)) < close)
		{
			speed = 1;
		}
		else if ((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x)) < mid)
		{
			if(speed >= 3)
				speed -= 1;
		}
		else if ((Mathf.Abs(player.transform.position.x - gameObject.transform.position.x)) < far)
		{
			speed = 2;
		}
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
