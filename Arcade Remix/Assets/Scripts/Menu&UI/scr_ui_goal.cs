using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ui_goal : MonoBehaviour {
    void Start()
    {
        StartCoroutine(OnBegin());
    }

    public IEnumerator OnBegin()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
