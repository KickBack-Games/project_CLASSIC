using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_spawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * Time.deltaTime * 2);
    }
}
