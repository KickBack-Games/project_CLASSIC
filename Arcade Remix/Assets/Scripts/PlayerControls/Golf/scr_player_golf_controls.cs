using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_player_golf_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    private Animator anim;
    public GameObject ball;
    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        button.onClick.AddListener(OnShoot);
        anim.speed = 0;
        global.winner = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.GetCurrentAnimatorStateInfo(0).length)
        {
            if (ball.GetComponent<scr_golf_ball_aim>().goSpeed == 0)
            {
                ball.GetComponent<scr_golf_ball_aim>().goSpeed = 9f;
                anim.Play("swing", -1, 0f);
                anim.speed = 0;
            }
        }
    }

    public void OnShoot() {
        anim.speed = 1;
        anim.Play("swing", - 1, 0f);
        ball.GetComponent<scr_golf_ball_aim>().spinSpeed.z = 0;
        ball.GetComponent<LineRenderer>().enabled = false;
    }
}
