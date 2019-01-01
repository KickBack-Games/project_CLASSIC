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
	
	// Update is called once per frame
	void Update () {
        if (scr_mod_fader.active)
        {
            if (global.gameMode==1)
            {
                if (global.winner)
                {
                    SceneManager.LoadScene(next, LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene("scn_title", LoadSceneMode.Single);
                }
            }
            if (global.gameMode == -1)
            {
                SceneManager.LoadScene("scn_lobby", LoadSceneMode.Single);
            }
            scr_mod_fader.active = false;
            scr_mod_fader.fadeSpeed = -1;
        }
    }

    public IEnumerator OnBegin()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        scr_mod_fader.fadeSpeed = 1;
    }
}
