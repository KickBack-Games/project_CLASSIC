using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gliding_missle : MonoBehaviour {
    public GameObject explode;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            explode.SetActive(true);
        }
    }
}
