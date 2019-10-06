using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponent : MonoBehaviour 
{
	private Vector2 pos;
	public float speed;

	public GameObject ball;
	private float myX;
	public float myY;

	void Start()
	{
		StartCoroutine(Example());
		pos = ball.transform.position;
		myX = ball.transform.position.x;
		myY = ball.transform.position.y;

	}
    void Update()
    {
    	myX = ball.transform.position.x;
    	pos = new Vector2(myX, myY);
 		transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        if (ball.transform.position.x > transform.position.x)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
        if (ball.transform.position.x < transform.position.x)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(Random.Range(2, 3));
        print("Now");
        myY = Random.Range(.75f, 4.5f);
        pos = new Vector2(transform.position.x, myY);
        StartCoroutine(Example());
    }
}
