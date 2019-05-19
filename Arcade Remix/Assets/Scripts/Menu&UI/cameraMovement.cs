using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public GameObject followPlayer;
	public float offset;

	private Vector2 temp = new Vector2();

    public bool follower = false;

    private Vector2 start;

    private void Start()
    {
        start = transform.position;
    }

    void Update ()
	 {
        if (follower)
        {
            temp = followPlayer.gameObject.GetComponent<Transform>().position;
            this.gameObject.GetComponent<Transform>().position = new Vector3(temp.x + offset, 0, -10);
        }
        else
        {
            transform.Translate(Vector3.right * 2 * Time.deltaTime);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "bg")
        {
            transform.position = start;
        }
    }
}
