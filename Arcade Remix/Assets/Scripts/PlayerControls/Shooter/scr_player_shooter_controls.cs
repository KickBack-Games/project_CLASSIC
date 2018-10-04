﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player_shooter_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    public GameObject UIEvent;
    //parent bullet to clone
    public GameObject bullet;
    //Ammo Limmit
    public int ammo = 5;
    //Movement speed
    public int speed = 3;
    //Timer for changing the player direction
    public int alarm = 60;
    public int alarmMin = 35;
    public int alarmMax = 55;
    //reload alarm
    public int alarmRe = -1;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(OnShoot);
        UIEvent.GetComponent<scr_ui_multiIcon>().OnRefresh(ammo);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        alarm--;
        alarmRe--;
        if (alarm == 0)
        {
            OnFlip();
        }
        if (alarmRe == 0)
        {
            ammo = 5;
            UIEvent.GetComponent<scr_ui_multiIcon>().OnRefresh(ammo);
            alarmRe = -1;
        }

        if (transform.position.x >= 2.3)
        {
            speed = Mathf.Abs(speed) * -1;
            alarm = Random.Range(alarmMin, alarmMax);
        }
        if (transform.position.x <= -2.6)
        {
            speed = Mathf.Abs(speed);
            alarm = Random.Range(alarmMin, alarmMax);
        }
    }

    void OnShoot() {
        if (ammo > 0)
        {
            ammo--;
            GameObject shot = Instantiate(bullet, this.transform.position, bullet.transform.rotation);
            shot.SetActive(true);
            UIEvent.GetComponent<scr_ui_multiIcon>().OnRefresh(ammo);
            if (ammo >= 0)
            {
                alarmRe = 60;
            }
        }
    }

    void OnFlip() {
        alarm = Random.Range(alarmMin, alarmMax);
        speed *= -1;
    }
}