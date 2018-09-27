using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_player_shooter_controls : MonoBehaviour {
    public Button button;
    public GameObject bullet;

    public GameObject bar;

    public int ammo = 5;
    public int alarm = 60;
    public int speed = 3;


	// Use this for initialization
	void Start () {
        button.onClick.AddListener(OnShoot);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        bar.transform.Translate(Vector2.right * Time.deltaTime * speed);
        alarm--;
        if (alarm <= 0)
        {
            alarm = Random.Range(40, 60);
            speed *= -1;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Main Camera")
        {
            alarm = Random.Range(40, 60);
            speed *= -1;
        }
    }

    void OnShoot() {
        if (ammo > 0)
        {
            ammo--;
            GameObject shot = Instantiate(bullet, this.transform.position, bullet.transform.rotation);
            shot.SetActive(true);            
        }
    }
}
