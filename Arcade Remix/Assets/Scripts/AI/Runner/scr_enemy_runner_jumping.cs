using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_jumping : MonoBehaviour {
    public GameObject goal;
    public int jspeed;
	// Use this for initialization
	void Start () {
        //jspeed = Random.Range(2, 5);

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jspeed);
        }
    }
}
