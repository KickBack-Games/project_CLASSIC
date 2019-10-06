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
        global.beatGames.Clear();
        global.lives = lives[difficulty-1];
        global.timeSec = global.timelimit;
        if (global.beatGames.Count == global.games.Count)
        {
            scr_mod_fader.fadeSpeed = 1;
            scr_mod_fader.next = "scn_lobby";
        }
        else
        {
            OnLevelSelect();
        }  
    }

    public void OnLevelSelect() {
        scr_mod_fader.next = global.games[Random.Range(0,global.games.Count)];
        if (global.beatGames.Contains(scr_mod_fader.next))
        {
            OnLevelSelect();
        }
        else
        {
            global.beatGames.Add(scr_mod_fader.next);
            scr_mod_fader.fadeSpeed = 1;
        }
    }
}
