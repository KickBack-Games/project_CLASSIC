using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_cloudspeed : MonoBehaviour {
    private int speed;
    public Sprite[] sprites;
	// Use this for initialization
	void Start () {
        speed = Random.Range(-6, -1);
        this.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
        }
    }
}
