using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_color_controls : MonoBehaviour {
    public float[] red;
    public float[] blue;
    public float[] green;
    public SpriteRenderer shield;

    public int num;
	// Use this for initialization
	void Start () {
        num = 0;
        OnPress();
	}
	
	// Update is called once per frame
	public void OnPress () {
        num++;
        if (num > 2) { num = 0; }
        shield.color = new Color(red[num], blue[num], green[num], 0.3843137f);
    }
}
