using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_game_timer : MonoBehaviour
{
    public Text counter;

    public GameObject results;
    public Text goalText;
    // Use this for initialization
    void Start()
    {
        if (global.timelimit > 0)
        {
            counter.text = "0:" + global.timeSec.ToString("D2");
            StartCoroutine(OnBegin());
        }
        else
        {
            counter.text = global.lives.ToString();
        }
    }

    private void Update()
    {
        if (global.timeSec <= 0 && global.timelimit > 0)
        {
            results.SetActive(true);
        }
        goalText.text = global.goalCounter.ToString();
    }

    public IEnumerator OnBegin()
    {
        yield return new WaitForSeconds(1);
        if (results.activeSelf==false)
        {
            global.timeSec--;
            counter.text = "0:" + global.timeSec.ToString("D2");
        }
        StartCoroutine(OnBegin());
    }
}
