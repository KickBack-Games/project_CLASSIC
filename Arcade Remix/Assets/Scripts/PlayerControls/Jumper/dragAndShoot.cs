using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndShoot : MonoBehaviour {

	private SpringJoint2D spring;
	public float maxStretch = 3.0f;
	public bool isPressed = false;

	private Ray raytoMouse;
	public Rigidbody2D rb;
	public float releaseTime = .15f;
	public float releaseTimeGrav = .3f;

	public float maxVelocity;

	public GameObject anchor;

	void Awake() 
	{
		//spring = GetComponent<SpringJoint2D>();
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		// if clicked mouse, then drag
		//GetComponent<Rigidbody2D>().gravityScale = 10;
		if (isPressed)
		{
			rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

	}

	void FixedUpdate()
	{
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
	}


	void OnMouseDown()
	{
		isPressed = true;
		rb.isKinematic = true;
		GetComponent<SpringJoint2D>().enabled = true;
		
		anchor.transform.position = gameObject.transform.position;
	}

	void OnMouseUp()
	{
	
		isPressed = false;
		rb.isKinematic = false;
		StartCoroutine(Release());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);
		GetComponent<SpringJoint2D>().enabled = false;

	}



	void dragging ()
	{
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}
}
