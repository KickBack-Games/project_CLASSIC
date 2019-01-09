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
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        scr_mod_fader.fadeSpeed = 1;
        scr_mod_fader.next = next;
    }
}
