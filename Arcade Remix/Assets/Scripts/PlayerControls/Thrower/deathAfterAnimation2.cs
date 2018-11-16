using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathAfterAnimation2 : MonoBehaviour {

	public Animation shrink;
	// Use this for initialization
	void Start ()
	 {
		shrink = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {

        shrink.Play();
        Destroy(gameObject, shrink.clip.length);
        print("Done");
	}
}
