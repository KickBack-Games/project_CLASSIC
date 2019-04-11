using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confettiPiece : MonoBehaviour 
{
	private Rigidbody2D rb;
	private Color[] colors = new Color[6];
	public float lifetime = 30;
	public float xSpeed;
	public float ySpeed;
	public float freq;
	public float delta = 2;
	public GameObject board;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		lifetime = Random.Range(10, 25);
 		// Get the colors!
        colors[0] = new Color(1f, 0f, 1f, 1f);			// Magenta
    	colors[1] = new Color(1f, 0f, 0f, 1f);			// Red
        colors[2] = new Color(0f, 1f, 1f, 1f);			// Cyan
        colors[3] = new Color(0f, 0f, 1f, 1f);			// Blue
      	colors[4] = new Color(0f, 1f, 0f, 1f);			// Green
        colors[5] = new Color(1f, 0.92f, 0.016f, 1f);	// Yellow
 
        SpriteRenderer temp = GetComponent<SpriteRenderer>();
        if( temp == null )
   			Debug.Log("fuck");
        temp.color = colors[Random.Range(0, colors.Length)];
        gameObject.transform.position = new Vector2(gameObject.transform.parent.position.x, gameObject.transform.parent.position.y + 3.5f);
        ySpeed = Random.Range(30f, 70f);
		xSpeed = Random.Range(-5f, 5f);
	}

	void Update()
	{
		rb.velocity = new Vector2(xSpeed, ySpeed);
		transform.Rotate (new Vector2(1050, 300) * Time.deltaTime);
		// Add gravity force, then keep it constant as it goes down
		if (ySpeed >= -5f)
		{
			ySpeed -= 1f;

		}
		else
			// Make it move.... weirdly on x axis
			xSpeed += delta * Mathf.Sin (Time.time * xSpeed);

		// Destroy
		lifetime -= freq;
		if (lifetime <= 0)
			Destroy(gameObject);

	}


}
