using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_game_launcher : MonoBehaviour {
    public Sprite[] icons; //0 tap | 1 pull | 2 swipe | 3 hold | 4 tilt

    public string toLoad;

    public GameObject messagebox;
    public Text message;
    public Image icon;
	// Use this for initialization
	void Start () {
        StartCoroutine(OnBegin());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator OnBegin() {
        yield return new WaitForSeconds(3);
        toLoad = global.games[Random.Range(0, global.games.Count)];
        messagebox.SetActive(true);
        if (toLoad == "scn_game_baseball") { message.text = "Hit the Ball!!"; icon.sprite = icons[0]; global.timelimit = 5; }
        if (toLoad == "scn_game_basketball") { message.text = "Make Three Goals!!"; icon.sprite = icons[1]; global.timelimit = 5; }
        if (toLoad == "scn_game_color") { message.text = "Match the Color!!"; icon.sprite = icons[0]; global.timelimit = 5; }
        if (toLoad == "scn_game_dodger") { message.text = "Dodge the Balls!!"; icon.sprite = icons[2]; global.timelimit = 5; }
        if (toLoad == "scn_game_gliding") { message.text = "Stay in the Air!!"; icon.sprite = icons[0]; global.timelimit = 5; }
        if (toLoad == "scn_game_golf") { message.text = "Get Three Holes!!"; icon.sprite = icons[0]; global.timelimit = 5; }
        if (toLoad == "scn_game_jumper") { message.text = "Board the Platforms!!"; icon.sprite = icons[1]; global.timelimit = 5; }
        if (toLoad == "scn_game_racing") { message.text = "Collect the Rings!!"; icon.sprite = icons[4]; global.timelimit = 5; }
        if (toLoad == "scn_game_runner") { message.text = "Avoid the Bumps!!"; icon.sprite = icons[2]; global.timelimit = 5; }
        if (toLoad == "scn_game_shooter") { message.text = "Shoot the Targets!!"; icon.sprite = icons[0]; global.timelimit = 5; }
        if (toLoad == "scn_game_skii") { message.text = "Touch Three Flags!!"; icon.sprite = icons[3]; global.timelimit = 5; }
        if (toLoad == "scn_game_tennis") { message.text = "Tap the Ball!!"; icon.sprite = icons[0]; global.timelimit = 5; }
        if (toLoad == "scn_game_thrower") { message.text = "Throw Really Far!!"; icon.sprite = icons[0]; global.timelimit = 5; }
        yield return new WaitForSeconds(2);
        messagebox.SetActive(false);
        SceneManager.LoadScene(toLoad, LoadSceneMode.Single);
    }
}
