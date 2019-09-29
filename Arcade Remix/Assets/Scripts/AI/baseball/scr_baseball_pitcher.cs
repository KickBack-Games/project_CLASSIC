using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_baseball_pitcher : MonoBehaviour {
    //touch button to fire 
    private Animator anim;

    public GameObject ball;
    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.GetCurrentAnimatorStateInfo(0).length)
        {
            GameObject n_ball = Instantiate(ball);
            n_ball.transform.position = ball.transform.position;
            n_ball.transform.localScale = ball.transform.lossyScale;
            n_ball.gameObject.name = "baseball";
            n_ball.SetActive(true);
            anim.Play("throw", -1, 0f);
            anim.speed = 0;
        }
    }

    public void OnShoot()
    {
        anim.speed = 1;
        anim.Play("throw", -1, 0f);
    }
}
