﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_gliding_player_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    public static int hits;
    void Start()
    {
        button.onClick.AddListener(OnJump);
        hits = 3;
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "missle")
        {
            hits--;
            GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
            other.GetComponent<BoxCollider2D>().enabled = false;
            if (hits <= 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y)* -1 );
            }
        }
        if (other.gameObject.name == "water")
        {
            hits = 0;
            GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
        }
        if (other.gameObject.name == "warp" && global.timelimit > 0)
        {
            SceneManager.LoadScene("scn_lobby", LoadSceneMode.Single);
        }
        if (other.gameObject.name == "ceiling")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) * -1);
        }
    }

    public void OnJump()
    {
        if (hits > 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        }
    }
}
