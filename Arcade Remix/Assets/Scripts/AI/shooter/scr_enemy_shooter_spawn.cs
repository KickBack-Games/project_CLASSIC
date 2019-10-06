using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_shooter_spawn : MonoBehaviour {
    public int alarm;
    public GameObject wave;
	// Use this for initialization
	void Start () {
        alarm = -1;
        OnRespawn();
	}
	
	// Update is called once per frame
	void Update () {
        alarm--;
        if (alarm == 0)
        {
            alarm = -1;
            OnRespawn();
        }
	}

    public void OnRespawn() {
        if (GameObject.FindGameObjectsWithTag("ShooterTarget").Length == 0 && alarm == -1)
        {
            GameObject newWave = Instantiate(wave.transform.GetChild(Random.Range(0, wave.gameObject.transform.childCount)).gameObject);
            newWave.transform.position = wave.gameObject.transform.GetChild(0).transform.position;
            newWave.gameObject.SetActive(true);
        }
    }
}
