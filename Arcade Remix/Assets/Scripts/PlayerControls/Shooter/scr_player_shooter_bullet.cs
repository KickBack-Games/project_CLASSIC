using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_shooter_bullet : MonoBehaviour {
    public GameObject eventobject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * Time.deltaTime * 12);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            global.scoreShooter += 500;
            global.goalCounter++;
            eventobject.GetComponent<scr_enemy_shooter_spawn>().alarm = 60;
        }
        if (other.gameObject.tag == "bad")
        {

            Destroy(gameObject);
        }
    }
}
