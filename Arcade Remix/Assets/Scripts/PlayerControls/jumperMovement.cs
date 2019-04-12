using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumperMovement : MonoBehaviour 
{
	public bool locked = false;
	public float maxX;
    public float maxY;

	private Rigidbody rb;

	public Vector2 initP;
	public Vector2 finalP;

	public float power;

	public GameObject anchor;
	public SpriteRenderer rend;

    public bool landed = false;
    public bool lost = false;
    public bool forceAdded = false;

    private LineRenderer line;
    public bool mouseOver = false;

    private float startY;

	void Start()
	{
		rend = anchor.GetComponent<SpriteRenderer>();
        line = GetComponent<LineRenderer>();
        startY = transform.position.y;
        rb = GetComponent<Rigidbody>();
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
		
	    if (Input.GetMouseButton(0) && landed)
		{
            if (mouseOver)
            {
                // This 'lock' allows the logic for dragging... since only when you let go, does it 
                // turn false
                locked = true;
                rb.velocity = new Vector3(0, 0, 0);

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
		}
		else
		{
			rend.enabled = false;
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

				if(initP.y > finalP.y)
					yDir = 1;
				else
					yDir = -1;

				// Find the real power (distance between x, and y vectors
				// subtract the x, and y
				float xDist = initP.x - finalP.x;
				float yDist = initP.y - finalP.y;

                xDist = Mathf.Clamp(xDist, maxX * -1, maxX);
                yDist = Mathf.Clamp(yDist, maxY * -1, maxY);

                xDist = Mathf.Abs(xDist);
				yDist = Mathf.Abs(yDist);
				// Can also set a max distance to avoid overpowering

				///  direction (probably 1, or -1... calculated by if statements of initP and finalP)* magnitude * power(which is a public float) 
				Vector3 supahPOWAH = new Vector3(xDir * power * xDist, yDir * power * yDist, 0);

				//Do physics
				gameObject.GetComponent<Rigidbody>().AddForce (supahPOWAH, ForceMode.Impulse);

				// Reset it
				initP = new Vector3 (0, 0, 0);
			}
			locked = false;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		landed = true;
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bad")
		{

		}
        if (other.gameObject.name == "Points" && gameObject.GetComponent<Rigidbody>().velocity.y <= 0)
        {

        }
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && transform.position.y < startY)
        {

        }
    }

    void OnCollisionExit(Collision other)
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


