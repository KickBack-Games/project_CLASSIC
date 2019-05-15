using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour {

	private bool hasLanded;

    private float travelDistance;
	public bool goingHorizontal = true;
    public bool goingVertical = false;

    private Vector2 pointA;
	private Vector2 pointB;

	public GameObject playah;

    public GameObject hazardPool;
    public GameObject spikePool;
    public GameObject firePool;

    public bool faller = false;
    public bool spikes = false;
    public bool fire = false;
    public bool bouncer = false;

    private bool spawned = false;

    void Start()
	{
		travelDistance = Random.Range(1f, 1.5f);
		hasLanded = false;
        pointA = transform.position;
		pointB = new Vector2 (pointA.x + travelDistance, pointA.y);
        if (spikes)
        {
            StartCoroutine(TimeSpike());
        }
        if (fire)
        {
            firePool.transform.position = new Vector2(Random.Range(GetComponent<Collider2D>().bounds.min.x, GetComponent<Collider2D>().bounds.max.x), firePool.transform.position.y);
        }

	}

	void Update()
	{
		if(!hasLanded)
		{
			if (goingHorizontal || goingVertical)
			{
				transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
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

	void OnCollisionEnter2D (Collision2D other)
	{
        hasLanded = true;
        if (bouncer)
        {
            GetComponent<Rigidbody2D>().sharedMaterial = null;
        }
        if (faller)
        {
            StartCoroutine(OnTimer());
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.GetComponent<jumperMovement>() == null) return;
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
        tmp.transform.position = new Vector3(playah.transform.position.x + 25f, Random.Range(-5.5f, 5.5f), transform.position.z);
        spawned = true;
    }

    public IEnumerator OnTimer()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
    public IEnumerator TimeSpike()
    {
        yield return new WaitForSeconds(2);
        if(spikePool.activeSelf)
        {
            spikePool.SetActive(false);
        }
        else
        {
            spikePool.SetActive(true);
        }
        StartCoroutine(TimeSpike());
    }
}

