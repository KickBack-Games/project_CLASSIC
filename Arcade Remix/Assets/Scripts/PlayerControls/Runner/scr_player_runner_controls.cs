using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_player_runner_controls : MonoBehaviour {
    //hits Limmit
    public int hits;
    //Movement speed
    public int speed = 3;
    public int jspeed = 7;
    private Animator anim;

    // Use this for initialization
    void Start () {
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
        SimpleGesture.On4AxisSwipeUp(OnJump);
        hits = 3;
        anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) { OnJump(); }
        if (hits <= 0 && global.timelimit > 0)
        {
            SceneManager.LoadScene("scn_lobby", LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnJump();
        }
        if (this.GetComponent<Rigidbody2D>().velocity.y == 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            anim.Play("run", -1, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RunnerEnemy")
        {
            collision.gameObject.GetComponent<scr_enemy_runner_jumping>().goal.SetActive(false);
            if (this.GetComponent<scr_mod_iframes>().alarm>-1)
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision, false);
            }
            else
            {
                hits--;
                GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
                this.GetComponent<scr_mod_iframes>().OnStart(60);
               
            }
        }
        if (collision.gameObject.tag == "RunnerGoal" && GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
        {
            global.scoreRunner += 500;
        }
    }

    void OnJump() {
        if(GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jspeed);
            anim.Play("jump", -1, 0f);
        }       
    }
}
