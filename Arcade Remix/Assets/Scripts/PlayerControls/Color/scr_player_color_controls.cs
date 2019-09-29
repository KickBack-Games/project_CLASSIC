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

    public static int tries;
    private void Start()
    {
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(3);
        OnRed();
        tries = 3;
        scr_game_launcher.winstate = 1;
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
