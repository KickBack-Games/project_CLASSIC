using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_game_start : MonoBehaviour {
    public int[] lives;
    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 60;   
    }

    public void OnBegin(int difficulty) {
        global.difficulty = difficulty;
        global.lives = lives[difficulty-1];
        global.timeSec = global.timelimit;
        scr_mod_fader.fadeSpeed = 1;
        scr_mod_fader.next = "scn_game_runner";
    }
}
