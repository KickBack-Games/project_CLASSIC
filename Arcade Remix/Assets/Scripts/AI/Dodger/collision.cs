using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
            Destroy(gameObject);
        global.scoreDodger += 20;
        
    }
}
