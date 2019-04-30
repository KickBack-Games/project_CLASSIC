using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpikeBed : platformMovement
{
    // Start is called before the first frame update
    public Transform[] Spikes;
    public Vector3 origianllocalscale = new Vector3();
    public float SpikesUpFactor = 1f;
    public bool SpikesUp = true;
    void Start()
    {
        SpikesUp = true;
        SpikesUpFactor = 1f;
        origianllocalscale = Spikes[0].transform.localScale;
        LastToggleTime = Time.time;
    }

    public Collider DamageCollider;
    // Update is called once per frame
    public float SpikeInterval = 1.5f;
    private float LastToggleTime = -10f;
    void FixedUpdate()
    {

        if (!hasLanded)
        if ((Time.time - LastToggleTime) >= SpikeInterval)
        {
            LastToggleTime = Time.time;
            SpikesUp = (!SpikesUp);
        }
            SpikesUpFactor = Mathf.Clamp01(SpikesUpFactor + ((Time.fixedDeltaTime*5f)* (SpikesUp?1f:-1f)));
         

        foreach (Transform sp in Spikes)
        {
            sp.transform.localScale = Vector3.Lerp(Vector3.zero,origianllocalscale,SpikesUpFactor);
        }
        DamageCollider.enabled = (SpikesUpFactor > .25f);


    }
}
