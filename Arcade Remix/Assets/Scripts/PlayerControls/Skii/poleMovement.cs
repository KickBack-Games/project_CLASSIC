using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poleMovement : MonoBehaviour {

	public GameObject skiier;
	public float speed;
	private float xSpawn = 2;
	public float ySpawn;

    public GameObject results;
	// Use this for initialization
	void Start () 
	{
		// Randomize initial x pos
        if (GetComponent<BoxCollider2D>() != null)
		transform.position = new Vector2(Random.Range(-xSpawn, xSpawn), transform.position.y);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.up * Time.deltaTime * speed);

		// Reset position if 'y' amount above player.y
		if (transform.position.y >= skiier.transform.position.y + 5f && GetComponent<BoxCollider2D>()!=null)
		{
            OnReset();
		}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "lost" && global.timeSec>0)
        {
            global.winner = false;
            results.SetActive(true);
        }
    }

    public void OnReset() {
        transform.position = new Vector2(Random.Range(-xSpawn, xSpawn), skiier.transform.position.y - 15);
    }
}
