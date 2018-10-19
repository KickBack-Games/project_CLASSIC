using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_golf_ball_aim : MonoBehaviour {
    public Vector3 spinSpeed;
    public LineRenderer line;

    void Start()
    {
        spinSpeed.x = 0;
        spinSpeed.y = 0;
        spinSpeed.z = Random.Range(0.2f, 0.5f);
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Debug.Log(transform.rotation.z);
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
}
