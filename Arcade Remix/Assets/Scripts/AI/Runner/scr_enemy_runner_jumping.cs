using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_jumping : MonoBehaviour {
    public GameObject goal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
        }
    }
}
