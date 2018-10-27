using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponent : MonoBehaviour 
{
	private Vector2 pos;
	public float speed;
	void Start()
	{
		StartCoroutine(Example());
		pos = transform.position;
	}
    void Update()
    {
    	
 		transform.position = Vector2.MoveTowards(transform.position, pos, Time.deltaTime * speed);

    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(Random.Range(3, 10));
        print("Now");
        pos = new Vector2(0, Random.Range(.75f, 4.5f));
        print(pos);
        StartCoroutine(Example());
    }
}
