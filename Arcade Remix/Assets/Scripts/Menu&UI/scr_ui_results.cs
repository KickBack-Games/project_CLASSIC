using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_ui_results : MonoBehaviour {
    public Sprite[] logo;

    public string next;
	// Use this for initialization
	void Start () {
        StartCoroutine(OnBegin());
        Time.timeScale = 0;
        if (global.winner)
        {
            this.GetComponent<Image>().sprite = logo[0];
        }
        else
        {
            this.GetComponent<Image>().sprite = logo[1];
        }
    }

    public IEnumerator OnBegin()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        scr_mod_fader.fadeSpeed = 1;
        if (!global.winner)
        {
            if (global.timelimit<=0)
            {
                if (global.lives > 0)
                {
                    global.lives--;
                    Scene scene = SceneManager.GetActiveScene();
                    scr_mod_fader.next = scene.name;
                }
                else
                {
                    scr_mod_fader.next = "scn_title";
                }
            }
        }
        else
        {
            if (global.beatGames.Count == global.games.Count)
            {
                scr_mod_fader.next = "scn_title";
            }
            else
            {
                OnLevelSelect();
            }
        }
    }
    public void OnLevelSelect()
    {
        scr_mod_fader.next = global.games[Random.Range(0, global.games.Count)];
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
