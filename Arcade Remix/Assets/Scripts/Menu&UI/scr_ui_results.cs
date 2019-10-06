using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_ui_results : MonoBehaviour {
    public Sprite[] logo;
	// Use this for initialization
	void Start () {

        StartCoroutine(OnBegin());
        //Time.timeScale = 0;
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
        //Time.timeScale = 1;
        scr_mod_fader.fadeSpeed = 1;
        scr_mod_fader.next = "scn_lobby";
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
