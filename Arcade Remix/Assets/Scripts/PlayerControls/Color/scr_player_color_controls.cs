using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player_color_controls : MonoBehaviour {
    public float[] red;
    public float[] blue;
    public float[] green;
    public Button[] button;
    public SpriteRenderer shield;

    public int num;
	// Use this for initialization
	void Start () {
        button[0].onClick.AddListener(OnRed);
        button[1].onClick.AddListener(OnBlue);
        button[2].onClick.AddListener(OnGreen);
    }
	
    public void OnRed() {
        num = 0;
        shield.color = new Color(red[0], blue[0], green[0], 0.3843137f);
    }
    public void OnBlue()
    {
        num = 1;
        shield.color = new Color(red[1], blue[1], green[1], 0.3843137f);
    }
    public void OnGreen()
    {
        num = 2;
        shield.color = new Color(red[2], blue[2], green[2], 0.3843137f);
    }
}
