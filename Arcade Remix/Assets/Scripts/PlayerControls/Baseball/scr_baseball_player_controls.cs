using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_baseball_player_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    private Animator anim;
    public static int balls;

    //hits Limmit
    public int tries = 5;
    // Use this for initialization
    void Start()
    {
        balls = 3;
        anim = this.GetComponent<Animator>();
        button.onClick.AddListener(OnShoot);
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(3);
        anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.GetCurrentAnimatorStateInfo(0).length)
        {
            anim.Play("swing", -1, 0f);
            anim.speed = 0;
        }
        if (balls <= 0 && global.timelimit > 0)
        {
            SceneManager.LoadScene("scn_lobby", LoadSceneMode.Single);
        }
    }

    public void OnShoot()
    {
        anim.speed = 1;
        anim.Play("swing", -1, 0f);
    }
}
