using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confetti : MonoBehaviour 
{

	private Color[] colors = new Color[6];
	public float lifetime = 2;
	public float xSpeed;
	public float ySpeed;
	public float freq;

	void Start()
	{
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
	}

	void Update()
	{
		// Add movement
		gameObject.transform.position = new Vector2(xSpeed, ySpeed);

		// Destroy
		lifetime -= freq;
		if (lifetime <= 0)
			Destroy(gameObject);

	}


}
