using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_AI_points : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name=="player")
        {
            global.score++;
            GameObject.Find("txtScore").GetComponent<Text>().text = global.score.ToString();
            Destroy(gameObject);
        }
    }
}
