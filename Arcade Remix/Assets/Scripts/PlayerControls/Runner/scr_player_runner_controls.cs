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

    public static int goal = 0;
    public Text goalText;

    public int[] goals;
    public GameObject results;
    // Use this for initialization
    void Start () {
        global.goalCounter = 0;
        goal = 0;        
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
        hits = 1;
        anim = this.GetComponent<Animator>();
        scr_game_launcher.winstate = 1;
        //goalText.text = "Clear " +goals[global.difficulty-1] +" hurdles!";
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) { OnJump(); }
        if (Input.GetKeyUp("space")) { OnDrop(); }
        if (hits <= 0 && global.timelimit > 0)
        {
            GameObject.Find("Results").SetActive(true);
        }

        if (this.GetComponent<Rigidbody2D>().velocity.y == 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            anim.Play("run", -1, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RunnerEnemy" && global.winner != true)
        {
            collision.gameObject.GetComponent<scr_enemy_runner_jumping>().goal.SetActive(false);
            if (this.GetComponent<scr_mod_iframes>().alarm>-1)
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision, false);
            }
            else
            {
                hits--;
                //hits =0;
                GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
                this.GetComponent<scr_mod_iframes>().OnStart(60);               
            }
            if (hits <= 0)
            {
                global.winner = false;
                results.GetComponent<scr_ui_results>().next = "scn_title";
                results.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "RunnerGoal" && GetComponent<Rigidbody2D>().velocity != new Vector2(0, 0))
        {
            global.scoreRunner += 500;
            goal++;
            global.goalCounter++;
            if (goal >= goals[global.difficulty - 1])
            {
                global.winner = true;
                results.GetComponent<scr_ui_results>().next = "scn_game_basketball";
                results.SetActive(true);
            }
        }
    }

    public void OnJump()
    {
        if (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jspeed);
            anim.Play("jump", -1, 0f);
        }
    }
    public void OnDrop()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
    }
}
