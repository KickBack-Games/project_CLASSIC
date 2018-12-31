using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_game_timer : MonoBehaviour
{
    public int time;
    public Text counter;
    public Image icon;
    public Image goalIcon;
    // Use this for initialization
    void Start()
    {
        if (global.timelimit > 0)
        {
            StartCoroutine(OnBegin());
            time = global.timelimit;
        }
        else
        {
            icon.sprite = goalIcon.sprite;
        }
    }

    private void Update()
    {
        if (global.timelimit == 0)
        {
            counter.text = global.goalCounter.ToString();
        }
    }

    public IEnumerator OnBegin()
    {
        for (int i = global.timelimit; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            counter.text = i.ToString();
        }
        SceneManager.LoadScene("scn_lobby", LoadSceneMode.Single);
    }
}
