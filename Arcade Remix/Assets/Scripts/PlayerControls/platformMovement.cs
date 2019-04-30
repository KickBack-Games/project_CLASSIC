using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {

	public bool hasLanded;
    public bool hasBounced;

    private float travelDistance;
	public bool goingHorizontal = true;
    public bool goingVertical = false;


    public Vector3 pointA;
	public Vector3 pointB;

	public GameObject playah;

    public GameObject hazardPool;

    public bool faller = false;
    public bool bouncer = false;

    private bool spawned = false;

	void Start()
	{
		travelDistance = Random.Range(.5f, 1f);
		hasLanded = false;
        hasBounced = false;
        pointA = transform.position;
		pointB = new Vector3 (pointA.x + ((goingHorizontal?1f:0f)*travelDistance), pointA.y+ ((goingVertical? 1f : 0f) * travelDistance), transform.position.z);
        
    }

	void Update()
	{
		if(!hasLanded)
		{
			if (goingHorizontal||goingVertical)
			{
				transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
			}
		}
        if (GameObject.Find("player").transform.position.x - transform.position.x >= 10 && !spawned)
        {
            teleportPlatform();
            hasLanded = false;
        }
        if (GameObject.Find("player").transform.position.x - transform.position.x >= 30)
        {
            Destroy(gameObject);
        }
    }

	void OnCollisionEnter(Collision other)
	{
		hasLanded = true;
        if (faller)
        {
            StartCoroutine(OnTimer());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<jumperMovement>() == null) return;
        //Debug.Log("Triggered!");
        if (bouncer)
        {
            //Debug.Log("Bounce");
            //if (!hasBounced)
            //{
            //Debug.Log("FORCE");
            if (other.gameObject.GetComponent<Rigidbody>().velocity.y <= 0f) {
                hasBounced = true;

                other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(other.gameObject.GetComponent<Rigidbody>().velocity.x, Mathf.Max(20f,Mathf.Abs(other.gameObject.GetComponent<Rigidbody>().velocity.y)), other.gameObject.GetComponent<Rigidbody>().velocity.z);
            }
            //}


        }
    }

	void teleportPlatform()
	{
        int children = hazardPool.transform.childCount;
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < children; ++i)
        {
            list.Add(hazardPool.transform.GetChild(i).gameObject);
        }

        //int hori = Random.Range(0,2);

        GameObject tmp = Instantiate(list[Random.Range(0, list.Count)].gameObject);
        tmp.SetActive(true);
		tmp.transform.position = new Vector3(playah.transform.position.x + 25f, Random.Range(-5.5f, 5.5f),transform.position.z);
        spawned = true;
    }

    public IEnumerator OnTimer() {
        yield return new WaitForSeconds(2);
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().useGravity = true;
    }
}

