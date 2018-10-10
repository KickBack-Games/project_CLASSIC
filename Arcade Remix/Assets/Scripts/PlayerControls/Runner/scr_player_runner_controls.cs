using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player_runner_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    public GameObject UIEvent;
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

    }

    void OnJump() {

    }
}
