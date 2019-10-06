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

    public Image thumbs;

    public GameObject players;
    public GameObject cheergood;
    public GameObject cheerbad;

    public GameObject speedup;
	void Start () {
        StartCoroutine(OnBegin());
        messagebox.SetActive(false);
        if (global.gamecount>0)
        {
            thumbs.transform.parent.gameObject.gameObject.SetActive(true);
            if (global.winner)
            {
                global.wincount++;
                cheergood.SetActive(true);
                if (global.wincount % 5 == 0)
                {
                    Time.timeScale = Time.timeScale + .50f;
                    speedup.SetActive(true);
                }
            }
            else
            {
                cheerbad.SetActive(true);
            }
        }

    }

    public IEnumerator OnBegin() {
        if (global.winner)
        {
            thumbs.color = new Color(0, 255, 0, 255);
        }
        if (!global.winner)
        {
            thumbs.color = new Color(255, 0, 0, 255);
            thumbs.gameObject.transform.localScale = new Vector3(thumbs.gameObject.transform.localScale.x, thumbs.gameObject.transform.localScale.y * - 1, thumbs.gameObject.transform.localScale.z);
        }
        yield return new WaitForSeconds(3);
        int rng = Random.Range(0, global.games.Count);
        toLoad = global.games[rng];
        //toLoad = "scn_game_thrower";
        thumbs.transform.parent.gameObject.SetActive(false);
        messagebox.SetActive(true);
        cheerbad.SetActive(false);
        cheergood.SetActive(false);
        players.transform.GetChild(rng).gameObject.SetActive(true);
        if (toLoad == "scn_game_baseball") { message.text = "Baseball"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_basketball") { message.text = "Basketball"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_dodger") { message.text = "Dodgeball"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_gliding") { message.text = "Hang Glide"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_golf") { message.text = "Golf"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_jumper") { message.text = "Plat Jumps"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_runner") { message.text = "Track Run"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_shooter") { message.text = "Archery"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_skii") { message.text = "Snowboard"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_tennis") { message.text = "Tennis"; icon.sprite = icons[rng];}
        if (toLoad == "scn_game_thrower") { message.text = "Shot Put"; icon.sprite = icons[rng];}
        yield return new WaitForSeconds(2);
        global.timeSec = 5;
        SceneManager.LoadScene(toLoad, LoadSceneMode.Single);
        global.gamecount++;
    }
}
