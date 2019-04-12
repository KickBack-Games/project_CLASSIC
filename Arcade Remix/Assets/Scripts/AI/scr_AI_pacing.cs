using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AI_pacing : MonoBehaviour {
    public float speed = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed);
	}

    public void OnCollisionExit2D(Collision2D other)
    {
        speed *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        if (other.gameObject.name == "ground")
        {

        }
    }
}
