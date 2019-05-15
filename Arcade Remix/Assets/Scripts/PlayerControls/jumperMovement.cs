using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumperMovement : MonoBehaviour 
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

    public bool landed = false;
    public bool lost = false;
    public bool forceAdded = false;

    private Animator anim;
    private LineRenderer line;
    public bool mouseOver = false;



	void Start()
	{
		rend = anchor.GetComponent<SpriteRenderer>();
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(0);
        scr_game_launcher.winstate = 1;
        anim = GetComponent<Animator>();
        line = GetComponent<LineRenderer>();
    }


	void Update () 
	{
		if (locked)
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            line.enabled = false;
        }
		
		if (!lost)
		{
	        if (Input.GetMouseButton(0) && landed)
			{
                if (mouseOver)
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
                            anim.Play("ready");
                            initP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            rend.transform.position = initP;
                            rend.enabled = true;
                        }
                    }
                }
			}
			else
			{
				rend.enabled = false;
				gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
				if (locked)
				{
                    anim.Play("jump");
					finalP = Camera.main.ScreenToWorldPoint(Input.mousePosition);

					// Find the direction
					int xDir;
					int yDir;
					if (initP.x > finalP.x)
						xDir = 1;
					else
						xDir = -1;

					if(initP.y > finalP.y)
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

					//Do physics
					gameObject.GetComponent<Rigidbody2D>().AddForce (supahPOWAH, ForceMode2D.Impulse);

					// Reset it
					initP = new Vector2 (0, 0);
				}
				locked = false;
			}
		}
		else
		{
			transform.Rotate( new Vector3(0, 0, 500) * Time.deltaTime);
			// falling effect
			if (transform.localScale.x >= 0 && transform.localScale.y >= 0)
			{
				Vector2 force_ = new Vector2(5f, 30f);
				transform.localScale -= new Vector3(0.01f, 0.01f, 0.0f);
				BoxCollider2D bc = gameObject.GetComponent<BoxCollider2D>();
				if (!forceAdded)
				{
					bc.enabled = false;
					this.gameObject.GetComponent<Rigidbody2D>().AddForce (force_, ForceMode2D.Impulse);
					forceAdded = true;	
				}
			}
		}
	}

	void FixedUpdate()
	{
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		landed = true;
        anim.Play("idle");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "bad")
		{
			lost = true;
		}
        if (other.gameObject.name == "Points" && gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            global.scoreJumper += 500;
        }
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Main Camera" && transform.position.y < other.transform.position.y)
        {
            SceneManager.LoadScene("scn_game_jumper", LoadSceneMode.Single);
        }
    }

    void OnCollisionExit2D(Collision2D other)
	{
		landed = false;
	}

    void OnMouseOver()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }
}


