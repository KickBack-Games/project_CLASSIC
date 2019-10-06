using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_player_shooter_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    //parent bullet to clone
    public GameObject bullet;
    //Movement speed
    public float speed = 3;
    //Timer for changing the player direction
    public int alarm = 60;
    public int alarmMin = 35;
    public int alarmMax = 55;

    private Animator anim;

    public GameObject results;

    // Use this for initialization
    void Start () {
        global.goalCounter = 5;
        button.onClick.AddListener(OnShoot);
        anim = this.GetComponent<Animator>();
        anim.speed = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (alarm == 0)
        {
            OnFlip();
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

        if (global.goalCounter==0)
        {
            global.winner = true;
            results.SetActive(true);
            Destroy(this);
        }
    }

    void OnShoot() {
        anim.speed = 2;
        anim.Play("shoot", -1, 0f);
    }

    public void OnFire()
    {
        GameObject shot = Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        shot.SetActive(true);
        shot.transform.parent = bullet.transform.parent;
        shot.transform.localScale = bullet.transform.localScale;
    }

    void OnFlip() {
        alarm = Random.Range(alarmMin, alarmMax);
        speed *= -1;
    }
}
