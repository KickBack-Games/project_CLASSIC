using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndShoot : MonoBehaviour {

	private SpringJoint2D spring;
	public float maxStretch = 3.0f;
	public bool clickedOn;

	private Ray raytoMouse;

	void Awake() 
	{
		spring = GetComponent<SpringJoint2D>();
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update () 
	{
		// if clicked mouse, then drag
		if (Input.GetMouseButtonDown(0))
		{
			//spring.enabled = false;
			clickedOn = true;
			Vector2 supahPOWAH = new Vector2(35.0f, 20.0f);
			this.gameObject.GetComponent<Rigidbody2D>().AddForce (supahPOWAH, ForceMode2D.Impulse);	
			if (Input.GetMouseButtonUp(0))
			{
				//spring.enabled = true;
				gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
				Debug.Log("Drag ended!");
			}
		}

	}



	void dragging ()
	{
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}
}
