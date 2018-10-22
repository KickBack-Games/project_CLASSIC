using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_golf_ball_aim : MonoBehaviour {
    public Vector3 spinSpeed;
    public LineRenderer line;

    public float goSpeed = 0;
    public GameObject spawner;
    void Start()
    {
        spinSpeed.x = 0;
        spinSpeed.y = 0;
        spinSpeed.z = Random.Range(0.2f, 0.5f);
        goSpeed = 0;
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        transform.Translate(Quaternion.Euler(0, 0, 0) * this.transform.up * goSpeed);
        gameObject.transform.Rotate(spinSpeed);
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
            Destroy(this.gameObject);
            spawner.GetComponent<scr_golf_goal_spawn>().OnSpawn();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            Destroy(this.gameObject);
            spawner.GetComponent<scr_golf_goal_spawn>().OnSpawn();
        }
    }
}
