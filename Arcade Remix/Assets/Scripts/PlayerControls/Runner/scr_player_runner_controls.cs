using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player_runner_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    //hits Limmit
    public int hits = 5;
    //Movement speed
    public int speed = 3;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(OnJump);
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * -13);
    }

    void OnJump() {
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(0, 10);
    }
}
