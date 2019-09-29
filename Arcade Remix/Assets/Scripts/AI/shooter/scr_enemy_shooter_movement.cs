using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_shooter_movement : MonoBehaviour {
    public int speedX;
    public int speedY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speedX);
        transform.Translate(Vector2.up * Time.deltaTime * speedY);

        if (transform.position.x >= 2.3)
        {
            speedX = Mathf.Abs(speedX) * -1;
        }
        if (transform.position.x <= -2.6)
        {
            speedX = Mathf.Abs(speedX);
        }

        if (transform.position.y >= 3.86)
        {
            speedY = Mathf.Abs(speedY) * -1;
        }
        if (transform.position.y <= 0.06)
        {
            speedY = Mathf.Abs(speedY);
        }
    }
}
