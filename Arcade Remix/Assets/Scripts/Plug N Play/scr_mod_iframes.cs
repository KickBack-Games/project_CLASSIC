using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_mod_iframes : MonoBehaviour {
    public int alarm;
    private SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (alarm % 10 == 0)
        {
            sprite.enabled = false;
        }
        else
        {
            sprite.enabled = true;
        }
        if (alarm > -1)
        {
            alarm--;
        }
        if (alarm==0)
        {

        }
    }

    public void OnStart(int iframes) {
        alarm = iframes;
    }
}
