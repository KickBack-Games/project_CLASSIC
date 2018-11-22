using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_game_timer : MonoBehaviour
{
    public int time;
    public Text counter;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(OnBegin());
        time = global.timelimit;
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
