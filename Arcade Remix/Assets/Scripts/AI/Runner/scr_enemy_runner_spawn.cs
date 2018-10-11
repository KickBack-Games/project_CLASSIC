using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_spawn : MonoBehaviour {
    private Vector3 startpos;
	// Use this for initialization
	void Start () {
        startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * Time.deltaTime * 2);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "MainCamera")
        {
           Instantiate(this,startpos,transform.localRotation);
            Destroy(this);
        }
    }
}
