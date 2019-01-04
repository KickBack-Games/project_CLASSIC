using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_game_start : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (scr_mod_fader.active)
        {
            SceneManager.LoadScene("scn_game_runner", LoadSceneMode.Single);
        }
    }

    public void OnBegin(int difficulty) {
        global.difficulty = difficulty;
        scr_mod_fader.fadeSpeed = 1;
    }
}
