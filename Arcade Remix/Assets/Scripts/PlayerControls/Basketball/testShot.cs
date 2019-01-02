using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testShot : MonoBehaviour
{

    public bool locked = false;
    public float maxVelocity;

    public Rigidbody2D rb;

    public Vector2 initP;
    public Vector2 finalP;

    public float power;

    public GameObject anchor;
    public SpriteRenderer rend;

    private float rotSpeed;

    public static int points;

    public bool touching;

    public int[] goals;
    public Text goalText;
    public Text timeText;
    public GameObject results;
    public int secs;

    // player jump
    public GameObject player;

    void Start()
    {
        points = 0;
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(0);
        scr_game_launcher.winstate = -1;
        global.goalCounter = 0;
        goalText.text = "Shoot " + goals[global.difficulty - 1] + " Baskets!";
        results.GetComponent<scr_ui_results>().next = "scn_game_dodger";
        secs = 15;
        StartCoroutine(OnBegin());
    }

    void Update()
    {
        if (secs <= 0)
        {
            global.winner = false;
            results.SetActive(true);
            Destroy(this);
        }
        if (global.goalCounter >= goals[global.difficulty - 1])
        {
            global.winner = true;
            results.SetActive(true);
            Destroy(this);
        }
        if (Input.GetMouseButton(0) && (gameObject.transform.position.y <= -10.5f))
        {
            // This 'lock' allows the logic for dragging... since only when you let go, does it 
            // turn false
            locked = true;
            // Stop ball from moving as player calculates shot
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            rb.velocity = new Vector2(0, 0);

            if (locked)
            {
                // We can get initial point
                if ((initP.x == 0) && (initP.y == 0))
                {
                    initP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    rend.transform.position = initP;
                    rend.enabled = true;
                }
            }
        }
        else
        {
            rend.enabled = false;
            if (!touching)
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;

            if (locked)
            {
                finalP = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Find the direction
                int xDir;
                int yDir;
                if (initP.x > finalP.x)
                    xDir = 1;
                else
                    xDir = -1;

                if (initP.y > finalP.y)
                    yDir = 1;
                else
                    yDir = -1;

                // Find the real power (distance between x, and y vectors
                // subtract the x, and y
                float xDist = initP.x - finalP.x;
                float yDist = initP.y - finalP.y;

                xDist = Mathf.Abs(xDist);
                yDist = Mathf.Abs(yDist);
                // Can also set a max distance to avoid overpowering

                ///  direction (probably 1, or -1... calculated by if statements of initP and finalP)* magnitude * power(which is a public float) 
                Vector2 supahPOWAH = new Vector2(xDir * power * xDist, yDir * power * yDist);
                if (yDist > 12)
                	yDist = 12;
                Vector2 jumpPOWAH = new Vector2(0, (yDir * power * yDist)/4);
                // Do physics
                gameObject.GetComponent<Rigidbody2D>().AddForce(supahPOWAH, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(jumpPOWAH, ForceMode2D.Impulse);

                // Reset it
                initP = new Vector2(0, 0);
                touching = false;
            }
            locked = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "stop") // For the opponents hitbox
        {
            touching = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
        }
    }

    public IEnumerator OnBegin()
    {
        yield return new WaitForSeconds(1);
        secs--;
        timeText.text = secs.ToString();
        StartCoroutine(OnBegin());
    }
}