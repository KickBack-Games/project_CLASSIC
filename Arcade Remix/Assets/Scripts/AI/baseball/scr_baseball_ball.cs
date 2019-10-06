using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_baseball_ball : MonoBehaviour {
    public int vspeed,hspeed;
    public GameObject pitcher;
    public GameObject results;
    // Use this for initialization
    void Start () {
        vspeed = Random.Range(8, 3);
        hspeed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * Time.deltaTime * vspeed);
        transform.Translate(Vector2.right * Time.deltaTime * hspeed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "BlastZone")
        {
            global.winner = false;
            results.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
            pitcher.GetComponent<scr_baseball_pitcher>().OnShoot();
            global.scoreBaseball += 200;
        }
    }
}
