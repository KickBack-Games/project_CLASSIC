using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class jumperMovement : MonoBehaviour 
{
	public bool locked = false;
	public float maxX;
    public float maxY;

	private Rigidbody rb;

	public Vector3 initP;
	public Vector3 finalP;

	public float power;

	public GameObject anchor;
	public SpriteRenderer rend;

    public bool landed = false;
    public bool lost = false;
    public bool forceAdded = false;

    private LineRenderer line;
    public bool mouseOver = false;

    private float startY;

    public Transform center;

    private Animator anim;
    public bool ScrollTesting = true;
	void Start()
	{
		rend = anchor.GetComponent<SpriteRenderer>();
        line = GetComponent<LineRenderer>();
        startY = transform.position.y;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        GameObject.Find("imgFill").GetComponent<Image>().fillAmount = 0;
        global.score = -1;
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    void Update () 
	{
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (rb.velocity.y > 1 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Up") && !landed)
            {
                anim.Play("Up");
            }
            if (rb.velocity.y < 1 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Down") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Land") && !landed)
            {
                anim.Play("Down");
            }

            if (locked)
            {
                line.enabled = true;
                line.SetPosition(0, center.position);
                line.SetPosition(1, GetWorldPositionOnPlane(Input.mousePosition, 0));

                float avgX = (initP.x - GetWorldPositionOnPlane(Input.mousePosition, 0).x) / maxX;
                float avgY = (initP.y - GetWorldPositionOnPlane(Input.mousePosition, 0).y) / maxY;

                avgX = Mathf.Clamp(avgX, 0, 1);
                avgY = Mathf.Clamp(avgY, 0, 1);

                float avg1 = (avgX + avgY) / 2;
                GameObject.Find("imgFill").GetComponent<Image>().fillAmount = avg1;
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
                        if ((initP.x == 0) && (initP.y == 0) && (initP.z == 0))
                        {
                            anim.Play("Crouch");
                            initP = GetWorldPositionOnPlane(Input.mousePosition, 0);
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
                    finalP = GetWorldPositionOnPlane(Input.mousePosition, 0);

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

                    xDist = Mathf.Clamp(xDist, maxX * -1, maxX);
                    yDist = Mathf.Clamp(yDist, maxY * -1, maxY);

                    xDist = Mathf.Abs(xDist);
                    yDist = Mathf.Abs(yDist);
                    // Can also set a max distance to avoid overpowering

                    ///  direction (probably 1, or -1... calculated by if statements of initP and finalP)* magnitude * power(which is a public float) 
                    Vector3 supahPOWAH = new Vector3(xDir * power * xDist, yDir * power * yDist, 0);

                    //Do physics
                    gameObject.GetComponent<Rigidbody>().AddForce(supahPOWAH, ForceMode.Impulse);

                    // Reset it
                    initP = new Vector3(0, 0, 0);

                    GameObject.Find("imgFill").GetComponent<Image>().fillAmount = 0;
                }
                locked = false;
            }
        }
	}

	void OnCollisionEnter(Collision other)
	{
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            landed = true;
            anim.Play("Land");
        }
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "bad")
		{
            if (!ScrollTesting)
                anim.Play("Die");
		}
        if (other.gameObject.name == "Points" && gameObject.GetComponent<Rigidbody>().velocity.y <= 0)
        {

        }
        
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && transform.position.y < startY)
        {
            if (!ScrollTesting)
            SceneManager.LoadScene("scn_game_jumper", LoadSceneMode.Single);
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

    void OnDie() {
        SceneManager.LoadScene("scn_game_jumper", LoadSceneMode.Single);
    }
}


