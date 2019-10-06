using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_confetti : MonoBehaviour {
    private Vector3 speed;
	// Use this for initialization
	void Start () {
        speed = new Vector3(Random.Range(0, 6), Random.Range(0, 6), Random.Range(0, 6));
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(speed, Space.Self);
	}
}
