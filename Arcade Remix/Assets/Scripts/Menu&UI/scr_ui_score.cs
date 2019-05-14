using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_ui_score : MonoBehaviour {
    public Text text;
    public Scene scene;
	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
        if (scene.name == "scn_game_baseball") { text.text = global.scoreBaseball.ToString("00000"); }
        if (scene.name == "scn_game_basketball") { text.text = global.scoreBasketball.ToString("00000"); }
        if (scene.name == "scn_game_color") { text.text = global.scoreColor.ToString("00000"); }
        if (scene.name == "scn_game_dodger") { text.text = global.scoreDodger.ToString("00000"); }
        if (scene.name == "scn_game_gliding") { text.text = global.scoreGliding.ToString("00000"); }
        if (scene.name == "scn_game_golf") { text.text = global.scoreGolf.ToString("00000"); }
        if (scene.name == "scn_game_jumper") { text.text = global.scoreJumper.ToString("00000"); }
        if (scene.name == "scn_game_racing") { text.text = global.scoreRacing.ToString("00000"); }
        if (scene.name == "scn_game_runner") { text.text = global.scoreRunner.ToString("00000"); }
        if (scene.name == "scn_game_shooter") { text.text = global.scoreShooter.ToString("00000"); }
        if (scene.name == "scn_game_skii") { text.text = global.scoreSkii.ToString("00000"); }
        if (scene.name == "scn_game_tennis") { text.text = global.scoreTennis.ToString("00000"); }
        if (scene.name == "scn_game_thrower") { text.text = global.scoreThrower.ToString("00000"); }
    }
}
