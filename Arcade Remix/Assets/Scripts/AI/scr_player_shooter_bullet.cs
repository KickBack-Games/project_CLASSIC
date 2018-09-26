using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_shooter_bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * Time.deltaTime * 5);
    }
}
