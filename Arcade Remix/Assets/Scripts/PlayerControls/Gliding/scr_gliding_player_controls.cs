using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_gliding_player_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;

    public float velocity;

    public GameObject results;
    void Start()
    {
        global.winner = true;
        button.onClick.AddListener(OnJump);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.y,-7f,7f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "missle" || other.gameObject.name == "water")
        {
            global.winner = false;
            results.SetActive(true);
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y)* -1 );
        }

        if (other.gameObject.name == "ceiling")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) * -1);
        }
    }

    public void OnJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    }
}
