using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_gliding_player_controls : MonoBehaviour {
    //touch button to fire 
    public Button button;
    public GameObject uievent;
    void Start()
    {
        button.onClick.AddListener(OnJump);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            GetComponent<Rigidbody2D>().velocity.y
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "spr_player_shooter")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
        }
    }

    public void OnJump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
    }
}
