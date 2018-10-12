using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy_runner_spawn : MonoBehaviour {
    public GameObject[] wave;
    public GameObject wave0;
	// Use this for initialization
	void Start () {
        OnSpawn();
	}

    public void OnSpawn() {
        GameObject newBlock = Instantiate(wave[global.level].transform.GetChild(Random.Range(0, wave[global.level].gameObject.transform.childCount)).gameObject);
        newBlock.transform.position = wave0.transform.position;
        newBlock.gameObject.SetActive(true);
    }
}
