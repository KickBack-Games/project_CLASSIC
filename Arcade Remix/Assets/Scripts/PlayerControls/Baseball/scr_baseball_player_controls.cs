using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_baseball_player_controls : MonoBehaviour {
    //touch button to fire 
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        anim.speed = 0;
        global.winner = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.GetCurrentAnimatorStateInfo(0).length)
        {
            anim.Play("swing", -1, 0f);
            anim.speed = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot();
        }
    }

    public void OnShoot()
    {
        anim.speed = 1;
        anim.Play("swing", -1, 0f);
    }
}
