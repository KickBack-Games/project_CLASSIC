using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_baseball_player_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    public GameObject uievent;
    private Animator anim;

    //hits Limmit
    public int tries = 5;
    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        button.onClick.AddListener(OnShoot);
        uievent.GetComponent<scr_ui_multiIcon>().OnRefresh(tries);
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
    }

    public void OnShoot()
    {
        anim.speed = 1;
        anim.Play("swing", -1, 0f);
    }
}
