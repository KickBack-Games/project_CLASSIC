using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class playerMovement : MonoBehaviour 
{

	private float speed = 7.0f;
	private Vector3 pos;
	private Transform tr;

	public bool lost;
	public Text txtScore;

    public void Awake()
    {
        SimpleGesture.On4AxisSwipeRight(SwipeRight);
        SimpleGesture.On4AxisSwipeDown(SwipeDown);
        SimpleGesture.On4AxisSwipeLeft(SwipeLeft);
        SimpleGesture.On4AxisSwipeUp(SwipeUp);
    }

    void Start() 
	{
		pos = transform.position;
		tr = transform;
		lost = false;
        GameObject.Find("EventSystem").GetComponent<scr_ui_multiIcon>().OnRefresh(0);
    }

	void Update() 
	{

		// Check to see if the player lost
		if ((pos.x >= 3) || 
			(pos.x <= -3) ||
			(pos.y >= 5) ||
			(pos.y <= -5))
			lost = true;

		if (lost)
		{
			transform.Rotate( new Vector3(0, 0, 500) * Time.deltaTime);
			// falling effect
			if (transform.localScale.x >= 0 && transform.localScale.y >= 0)
				transform.localScale -= new Vector3(0.01f, 0.01f, 0.0f);
			else
				// Restart when completely shrunk
                if (global.timelimit > 0)
            {
                SceneManager.LoadScene("scn_lobby", LoadSceneMode.Single);
            }
				
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.D))
			{
                SwipeRight();
			}
			else if (Input.GetKeyDown(KeyCode.A)) 
			{
                SwipeLeft();
			}
			else if (Input.GetKeyDown(KeyCode.W)) 
			{
                SwipeUp();
			}
			else if (Input.GetKeyDown(KeyCode.S)) 
			{
                SwipeDown();
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
	}   

	// HANDLE THE COLLISION HERE
    void OnTriggerEnter2D(Collider2D other)
    {
    	if (!lost)
    	{
	    	ballMovement ballScript = other.GetComponent<ballMovement>();
	    	int dir = ballScript.dir;

	        if (other.gameObject.tag == "ball")
	    	{
	    		Destroy(other.gameObject);
	    		if (dir == 0)
	    			pos += Vector3.up * 2;
	            else if (dir == 1)
	            	pos += Vector3.down * 2;
	            else if (dir == 2)
	            	pos += Vector3.right * 2;
	            else
	            	pos += Vector3.left * 2;
	        }
    	}
    }

    public void SwipeUp()
    {
        if (tr.position == pos)
        {
            pos += Vector3.up;
        }
    }
    public void SwipeDown()
    {
        if (tr.position == pos)
        {
            pos += Vector3.down;
        }
    }
    public void SwipeLeft()
    {
        if (tr.position == pos)
        {
            pos += Vector3.left;
        }
    }
    public void SwipeRight()
    {
        if(tr.position == pos)
        {
            pos += Vector3.right;
        }
    }
}
