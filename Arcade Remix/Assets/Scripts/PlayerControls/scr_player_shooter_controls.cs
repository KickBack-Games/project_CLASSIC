using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player_shooter_controls : MonoBehaviour {
    public Button button;
    public GameObject bullet;

    public int ammo = 5;
	// Use this for initialization
	void Start () {
        button.onClick.AddListener(OnShoot);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnShoot() {
        if (ammo > 0)
        {
            ammo--;
            GameObject shot = Instantiate(bullet, this.transform.position, bullet.transform.rotation);
            bullet.SetActive(true);
        }
    }
}
