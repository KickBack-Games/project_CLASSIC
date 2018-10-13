using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player_runner_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    public GameObject uievent;
    //hits Limmit
    public int hits = 5;
    //Movement speed
    public int speed = 3;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(OnJump);
        uievent.GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) { OnJump(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RunnerEnemy")
        {
            if (this.GetComponent<scr_mod_iframes>().alarm>-1)
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision, false);
            }
            else
            {
                hits--;
                uievent.GetComponent<scr_ui_multiIcon>().OnRefresh(hits);
                this.GetComponent<scr_mod_iframes>().OnStart(60);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "RunnerGoal")
        {
            global.scoreRunner += 500;
        }
    }

    void OnJump() {
        if(GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 7);
        }       
    }
}
