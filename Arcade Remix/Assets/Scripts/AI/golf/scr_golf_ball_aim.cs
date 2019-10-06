using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_golf_ball_aim : MonoBehaviour {
    public Vector3 spinSpeed;
    public LineRenderer line;

    public float goSpeed = 0;
    public GameObject spawner;

    public GameObject results;
    void Start()
    {
        spinSpeed.x = 0;
        spinSpeed.y = 0;
        spinSpeed.z = 24f;
        goSpeed = 0;
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        transform.Translate(Quaternion.Euler(0, 0, 0) * this.transform.up * goSpeed * Time.deltaTime);
        gameObject.transform.Rotate(spinSpeed * Time.deltaTime);
        line.SetPosition(1, (Quaternion.Euler(0, 0, 0) * this.transform.up) * 500);
        if (transform.rotation.z > 0.21 && spinSpeed.z > 0)
        {
            spinSpeed.z *= -1;
        }
        if (transform.rotation.z < -0.21 && spinSpeed.z < 0)
        {
            spinSpeed.z *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "goal")
        {
            global.winner = true;
            results.SetActive(true);
            Destroy(this.gameObject);
            global.scoreGolf += 200;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            global.winner = false;
            results.SetActive(true);
            Destroy(this.gameObject);
            spawner.GetComponent<scr_golf_goal_spawn>().OnSpawn();
        }
    }
}
