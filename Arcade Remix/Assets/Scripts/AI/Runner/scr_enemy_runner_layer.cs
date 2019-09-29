using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_layer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<SpriteRenderer>().sortingOrder = global.layer;
        global.layer--;
	}
}
