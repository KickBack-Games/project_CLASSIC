using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyclingBackground : MonoBehaviour
{
    // Start is called before the first frame update
    public cameraMovement theCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    public const float backgroundDifference = ((215f - (-15.6f)));
    void Update()
    {
        float dif = Mathf.Abs(theCamera.transform.position.x - this.transform.position.x);
        if (dif > backgroundDifference*1.5f)
        {
            this.transform.position = new Vector3(this.transform.position.x+(backgroundDifference*3f*Mathf.Sign(dif)),this.transform.position.y, this.transform.position.z);
            Debug.Log("Cycle!");
        }
        
    }
}
