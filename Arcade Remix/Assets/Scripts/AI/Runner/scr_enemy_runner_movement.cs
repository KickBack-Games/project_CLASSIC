using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_movement : MonoBehaviour {
    public GameObject parent;
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * Time.deltaTime * 4);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera" && this.gameObject.name!="firstwave")
        {
            parent.GetComponent<scr_enemy_runner_spawn>().OnSpawn();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            global.scoreGliding += 200;
            Destroy(this.gameObject);
        }
    }
}
