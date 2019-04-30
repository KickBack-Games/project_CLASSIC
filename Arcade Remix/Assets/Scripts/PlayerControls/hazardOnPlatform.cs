using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardOnPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PointA, PointB;
    public bool MoveToggle = false;
    public float Speed = 1f;
    public float IdleDuration = 1f;
    void Start()
    {
        //desttime = 0f;
    }

    // Update is called once per frame
    private float desttime = 0f;
    void FixedUpdate()
    {

        float del = (Speed * Time.fixedDeltaTime);
        Vector3 dest = (MoveToggle ? PointB.position: PointA.position);
        if ((this.transform.position - dest).magnitude < del)
        {
            this.transform.position = dest;
            desttime += Time.fixedDeltaTime;
            if (desttime >= IdleDuration)
            {
                MoveToggle = !MoveToggle;
            }
        } else
        {
            this.transform.position = this.transform.position + ((dest - this.transform.position).normalized*del);
            desttime = 0f;
        }
    }
}
