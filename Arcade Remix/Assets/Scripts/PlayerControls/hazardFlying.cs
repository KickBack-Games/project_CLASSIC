using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardFlying : MonoBehaviour
{
    private Vector3 StartPosition;
    
    public Vector2 MoveRanges = new Vector2(3f,1f);
    public Vector2 MoveTimes = new Vector2(1f, .5f);
    private float StartTime;
    void Start()
    {
        StartPosition = this.transform.position;
        StartTime = Time.time;
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {

        float ts = ((Time.time - StartTime)*(Mathf.PI*2f));
        transform.position = (StartPosition + new Vector3(MoveRanges.x * -Mathf.Sin((ts/MoveTimes.x)), MoveRanges.y * Mathf.Sin(ts / MoveTimes.y), 0f));
        
    }
}
