using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_racer_player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime*3);
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(new Vector3(0,-1,0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
