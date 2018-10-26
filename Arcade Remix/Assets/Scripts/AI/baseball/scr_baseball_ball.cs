using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_baseball_ball : MonoBehaviour {
    public int vspeed,hspeed;
    public GameObject pitcher;
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

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
            pitcher.GetComponent<scr_baseball_pitcher>().OnShoot();
        }
    }
}
