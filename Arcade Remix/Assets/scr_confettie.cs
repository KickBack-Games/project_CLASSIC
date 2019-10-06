using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_confettie : MonoBehaviour {
    public GameObject conf;

    private Color[] colors = new Color[6];
    // Use this for initialization
    void Start () {
        StartCoroutine(TimeSpawn());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator TimeSpawn() {
        yield return new WaitForSeconds(0.5f);
        for (int i=0; i<=10; i++)
        {
            GameObject tmp = Instantiate(conf);
            tmp.SetActive(true);
            tmp.transform.parent = transform;
            tmp.transform.position = new Vector2(Random.Range(GetComponent<BoxCollider2D>().bounds.min.x, GetComponent<BoxCollider2D>().bounds.max.x),
                Random.Range(GetComponent<BoxCollider2D>().bounds.min.y, GetComponent<BoxCollider2D>().bounds.max.y));

            colors[0] = new Color(1f, 0f, 1f, 1f);          // Magenta
            colors[1] = new Color(1f, 0f, 0f, 1f);          // Red
            colors[2] = new Color(0f, 1f, 1f, 1f);          // Cyan
            colors[3] = new Color(0f, 0f, 1f, 1f);          // Blue
            colors[4] = new Color(0f, 1f, 0f, 1f);          // Green
            colors[5] = new Color(1f, 0.92f, 0.016f, 1f);   // Yellow
            tmp.transform.localScale = conf.transform.localScale;
            tmp.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
        }
        StartCoroutine(TimeSpawn());
    }
}
