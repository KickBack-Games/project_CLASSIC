using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

	public GameObject objToFollow;

	private Vector2 temp = new Vector2();

	public float xRan;
	public float yRan;

	// Update is called once per frame
	void Update () 
	{

        if (Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<Transform>().position = new Vector2(Random.Range(-xRan, xRan),
                                                                             Random.Range(-yRan + 2.67f, yRan + 2.67f));
        }
        else
            this.gameObject.GetComponent<Transform>().position = new Vector2(0, 2.67f);
    }
}
