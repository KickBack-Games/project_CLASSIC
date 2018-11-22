using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_player_golf_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    private Animator anim;

    public static int holes;

    public GameObject ball;
    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        button.onClick.AddListener(OnShoot);
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(0);
        anim.speed = 0;
        holes = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.GetCurrentAnimatorStateInfo(0).length)
        {
            if (ball.GetComponent<scr_golf_ball_aim>().goSpeed == 0)
            {
                ball.GetComponent<scr_golf_ball_aim>().goSpeed = 0.1f;
                anim.Play("swing", -1, 0f);
                anim.speed = 0;
            }
        }
        if (holes >= 3)
        {
            SceneManager.LoadScene("scn_lobby", LoadSceneMode.Single);
        }
    }

    public void OnShoot() {
        anim.speed = 1;
        anim.Play("swing", - 1, 0f);
        ball.GetComponent<scr_golf_ball_aim>().spinSpeed.z = 0;
        ball.GetComponent<LineRenderer>().enabled = false;
    }
}
