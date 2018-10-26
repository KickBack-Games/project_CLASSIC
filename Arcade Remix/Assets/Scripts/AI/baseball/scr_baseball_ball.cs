using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_baseball_ball : MonoBehaviour {
    public int vspeed,hspeed;
    // Use this for initialization
    void Start () {
        vspeed = Random.Range(6, 1) * global.level;
        hspeed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime * vspeed);
        transform.Translate(Vector2.right * Time.deltaTime * hspeed);
    }
}
