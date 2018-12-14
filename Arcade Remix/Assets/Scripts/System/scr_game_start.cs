using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_game_start : MonoBehaviour {
    public string[] easyLevels;
    public string[] mediumLevels;
    public string[] hardLevels;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (scr_mod_fader.active)
        {
            if (global.difficulty == 1)
            {
                SceneManager.LoadScene(easyLevels[0], LoadSceneMode.Single);
            }
            if (global.difficulty == 2)
            {
                SceneManager.LoadScene(mediumLevels[0], LoadSceneMode.Single);
            }
            if (global.difficulty == 3)
            {
                SceneManager.LoadScene(hardLevels[0], LoadSceneMode.Single);
            }
        }
	}

    public void OnBegin(int difficulty) {
        global.difficulty = difficulty;
        scr_mod_fader.fadeSpeed = 1;
    }
}
